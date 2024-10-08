﻿using UnityEngine;
using UniFramework.Machine;
using YooAsset;
using Cysharp.Threading.Tasks;

/// <summary>
/// 更新资源版本号
/// </summary>
internal class FsmUpdatePackageVersion : IStateNode
{
    private StateMachine _machine;

    void IStateNode.OnCreate(StateMachine machine)
    {
        _machine = machine;
    }
    async void IStateNode.OnEnter()
    {
        EventCenter.Instance.Fire<string>((int)EventEnumAOT.EE_PatchStatesChange, "获取最新的资源版本！");
        //GameMain.Instance.StartCoroutine(UpdatePackageVersion());

        await UpdatePackageVersion();
    }
    void IStateNode.OnUpdate()
    {
    }
    void IStateNode.OnExit()
    {
    }

    private async UniTask UpdatePackageVersion()
    {
        //yield return new WaitForSecondsRealtime(0.5f);
        await UniTask.WaitForSeconds(0.5f);

        var packageName = (string)_machine.GetBlackboardValue("PackageName");
        var package = YooAssets.GetPackage(packageName);
        var operation = package.UpdatePackageVersionAsync();
        //yield return operation;
        await operation;

        if (operation.Status != EOperationStatus.Succeed)
        {
            Debug.LogWarning(operation.Error);
            EventCenter.Instance.Fire((int)EventEnumAOT.EE_PackageVersionUpdateFailed);
        }
        else
        {
            _machine.SetBlackboardValue("PackageVersion", operation.PackageVersion);
            _machine.ChangeState<FsmUpdatePackageManifest>();
        }
    }
}