using UniFramework.Machine;
using YooAsset;
using Cysharp.Threading.Tasks;

/// <summary>
/// 下载更新文件
/// </summary>
public class FsmDownloadPackageFiles : IStateNode
{
    private StateMachine _machine;

    void IStateNode.OnCreate(StateMachine machine)
    {
        _machine = machine;
    }
    async void IStateNode.OnEnter()
    {
        EventCenter.Instance.Fire<string>((int)EventEnumAOT.EE_PatchStatesChange, "开始下载补丁文件！");
        await BeginDownload();
    }
    void IStateNode.OnUpdate()
    {
    }
    void IStateNode.OnExit()
    {
    }

    private async UniTask BeginDownload()
    {
        var downloader = (ResourceDownloaderOperation)_machine.GetBlackboardValue("Downloader");
        downloader.OnDownloadErrorCallback = OnEventWebFileDownloadFailed;// PatchEventDefine.WebFileDownloadFailed.SendEventMessage;
        downloader.OnDownloadProgressCallback = OnEventDownloadProgressUpdate;
        downloader.BeginDownload();
        //yield return downloader;
        await downloader;

        // 检测下载结果
        if (downloader.Status != EOperationStatus.Succeed)
            return;//   yield break;

        _machine.ChangeState<FsmDownloadPackageOver>();
    }

    private void OnEventDownloadProgressUpdate(int totaldownloadcount, int currentdownloadcount, long totaldownloadbytes, long currentdownloadbytes)
    {
        EventCenter.Instance.Fire<int, int, long, long>((int)EventEnumAOT.EE_DownloadProgressUpdate, totaldownloadcount, currentdownloadcount, totaldownloadbytes, currentdownloadbytes);
    }

    private void OnEventWebFileDownloadFailed(string filename, string error)
    {
        EventCenter.Instance.Fire<string, string>((int)EventEnumAOT.EE_WebFileDownloadFailed, filename, error);
    }
}