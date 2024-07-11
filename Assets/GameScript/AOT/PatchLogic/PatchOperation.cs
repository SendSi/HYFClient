using UniFramework.Machine;
using UniFramework.Event;
using YooAsset;

public class PatchOperation : GameAsyncOperation
{
    private enum ESteps
    {
        None,
        Update,
        Done,
    }

    private readonly EventGroup _eventGroup = new EventGroup();
    private readonly StateMachine _machine;
    private ESteps _steps = ESteps.None;

    public PatchOperation(string packageName, string buildPipeline, EPlayMode playMode)
    {
        // 注册监听事件
        EventCenter.Instance.Bind((int)EventEnum.EE_UserTryInitialize, OnEventUserTryInitialize);
        EventCenter.Instance.Bind((int)EventEnum.EE_UserBeginDownloadWebFiles, OnEventUserBeginDownloadWebFiles);
        EventCenter.Instance.Bind((int)EventEnum.EE_UserTryUpdatePackageVersion, OnEventUserTryUpdatePackageVersion);
        EventCenter.Instance.Bind((int)EventEnum.EE_UserTryUpdatePatchManifest, OnEventUserTryUpdatePatchManifest);
        EventCenter.Instance.Bind((int)EventEnum.EE_UserTryDownloadWebFiles, OnEventUserTryDownloadWebFiles);

        // 创建状态机
        _machine = new StateMachine(this);
        _machine.AddNode<FsmInitializePackage>();
        _machine.AddNode<FsmUpdatePackageVersion>();
        _machine.AddNode<FsmUpdatePackageManifest>();
        _machine.AddNode<FsmCreatePackageDownloader>();
        _machine.AddNode<FsmDownloadPackageFiles>();
        _machine.AddNode<FsmDownloadPackageOver>();
        _machine.AddNode<FsmClearPackageCache>();
        _machine.AddNode<FsmUpdaterDone>();

        _machine.SetBlackboardValue("PackageName", packageName);
        _machine.SetBlackboardValue("PlayMode", playMode);
        _machine.SetBlackboardValue("BuildPipeline", buildPipeline);
    }

    private void OnEventUserTryUpdatePatchManifest()
    {
        _machine.ChangeState<FsmUpdatePackageManifest>();
    }

    private void OnEventUserTryUpdatePackageVersion()
    {
        _machine.ChangeState<FsmUpdatePackageVersion>();
    }

    private void OnEventUserBeginDownloadWebFiles()
    {
        _machine.ChangeState<FsmDownloadPackageFiles>();
    }

    private void OnEventUserTryInitialize()
    {
        _machine.ChangeState<FsmInitializePackage>();
    }

    void OnEventUserTryDownloadWebFiles()
    {
        _machine.ChangeState<FsmCreatePackageDownloader>();
    }
    
    protected override void OnStart()
    {
        _steps = ESteps.Update;
        _machine.Run<FsmInitializePackage>();
    }
    
    protected override void OnUpdate()
    {
        if (_steps == ESteps.None || _steps == ESteps.Done)
            return;

        if (_steps == ESteps.Update)
        {
            _machine.Update();
            if (_machine.CurrentNode == typeof(FsmUpdaterDone).FullName)
            {
                RemoveEventCenters();
                Status = EOperationStatus.Succeed;
                _steps = ESteps.Done;
            }
        }
    }

    protected override void OnAbort()
    {
    }

    void RemoveEventCenters()
    {
        EventCenter.Instance.UnBind((int)EventEnum.EE_UserTryInitialize, OnEventUserTryInitialize);
        EventCenter.Instance.UnBind((int)EventEnum.EE_UserBeginDownloadWebFiles, OnEventUserBeginDownloadWebFiles);
        EventCenter.Instance.UnBind((int)EventEnum.EE_UserTryUpdatePackageVersion, OnEventUserTryUpdatePackageVersion);
        EventCenter.Instance.UnBind((int)EventEnum.EE_UserTryUpdatePatchManifest, OnEventUserTryUpdatePatchManifest);
        EventCenter.Instance.UnBind((int)EventEnum.EE_UserTryDownloadWebFiles, OnEventUserTryDownloadWebFiles);
    }


}