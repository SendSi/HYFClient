using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniFramework.Machine;
using YooAsset;
using Cysharp.Threading.Tasks;

/// <summary>
/// 更新资源清单
/// </summary>
public class FsmUpdatePackageManifest : IStateNode
{
    private StateMachine _machine;

    void IStateNode.OnCreate(StateMachine machine)
    {
        _machine = machine;
    }
    async void IStateNode.OnEnter()
    {
        EventCenter.Instance.Fire<string>((int)EventEnum.EE_PatchStatesChange, "更新资源清单！");
        await UpdateManifest();
    }
    void IStateNode.OnUpdate()
    {
    }
    void IStateNode.OnExit()
    {
    }

    private async UniTask UpdateManifest()
    {
        //yield return new WaitForSecondsRealtime(0.5f);
        await UniTask.WaitForSeconds(0.5f);

        var packageName = (string)_machine.GetBlackboardValue("PackageName");
        var packageVersion = (string)_machine.GetBlackboardValue("PackageVersion");
        var package = YooAssets.GetPackage(packageName);
        bool savePackageVersion = true;
        var operation = package.UpdatePackageManifestAsync(packageVersion, savePackageVersion);
        //yield return operation;
        await operation;

        if (operation.Status != EOperationStatus.Succeed)
        {
            Debug.LogWarning(operation.Error);
            // PatchEventDefine.PatchManifestUpdateFailed.SendEventMessage();
            EventCenter.Instance.Fire((int)EventEnum.EE_PatchManifestUpdateFailed);

            //yield break;
            return;
        }
        else
        {
            _machine.ChangeState<FsmCreatePackageDownloader>();
        }
    }
}