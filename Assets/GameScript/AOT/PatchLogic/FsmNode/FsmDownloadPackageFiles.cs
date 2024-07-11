using System.Collections;
using UnityEngine;
using UniFramework.Machine;
using YooAsset;

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
    void IStateNode.OnEnter()
    {
        EventCenter.Instance.Fire<string>((int)EventEnum.EE_PatchStatesChange, "开始下载补丁文件！");
        GameMain.Instance.StartCoroutine(BeginDownload());
    }
    void IStateNode.OnUpdate()
    {
    }
    void IStateNode.OnExit()
    {
    }

    private IEnumerator BeginDownload()
    {
        var downloader = (ResourceDownloaderOperation)_machine.GetBlackboardValue("Downloader");
        downloader.OnDownloadErrorCallback = OnEventWebFileDownloadFailed;// PatchEventDefine.WebFileDownloadFailed.SendEventMessage;
        downloader.OnDownloadProgressCallback = OnEventDownloadProgressUpdate;
        downloader.BeginDownload();
        yield return downloader;

        // 检测下载结果
        if (downloader.Status != EOperationStatus.Succeed)
            yield break;

        _machine.ChangeState<FsmDownloadPackageOver>();
    }

    private void OnEventDownloadProgressUpdate(int totaldownloadcount, int currentdownloadcount, long totaldownloadbytes, long currentdownloadbytes)
    {
        EventCenter.Instance.Fire<int, int, long, long>((int)EventEnum.EE_DownloadProgressUpdate, totaldownloadcount, currentdownloadcount, totaldownloadbytes, currentdownloadbytes);
    }

    private void OnEventWebFileDownloadFailed(string filename, string error)
    {
        EventCenter.Instance.Fire<string, string>((int)EventEnum.EE_WebFileDownloadFailed, filename, error);
    }
}