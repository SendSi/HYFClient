using System;
using FairyGUI;
using UnityEngine;
using UnityEngine.Video;
using YooAsset;

/// <summary> 播放视频    用的是json的导表   1.在fgui上加个GLoader 然后调用PlayVideoId()     2.关闭页面时调用ClearVideo() </summary>
public class VideoMgr : Singleton<VideoMgr>
{
    private GameObject videoGo;
    private VideoPlayer videoCom;
    private RenderTexture renderTexture;
    AssetHandle videoHandle;

    void LoadCom(int width, int height)
    {
        videoGo = new GameObject("videoPlayer");
        videoCom = videoGo.AddComponent<VideoPlayer>();
        renderTexture = RenderTexture.GetTemporary(width, height, 16);
    }

    /// <summary> 播放视频视频      </summary>
    public void PlayVideoId(string idStr, GLoader pCom)
    {
        LoadCom((int)pCom.width, (int)pCom.height);
        var cfg = CfgJsonMgr.Instance.LoadConfigOne<VideoConfig>(idStr);
        if (cfg != null)
        {
            UsingVideoAsset(cfg.yooPath, pCom);
        }
    }

    public void UsingVideoAsset(string pRes, GLoader pCom)
    {
        LoadVideoAsset(pRes, (ah) =>
        {
            pCom.visible = true;
            videoHandle = ah;
            var asset = ah.AssetObject as VideoClip;
            videoCom.clip = asset;
            videoCom.isLooping = true;
            videoCom.aspectRatio = VideoAspectRatio.Stretch;
            videoCom.targetTexture = renderTexture;
            var texture = new NTexture(renderTexture);
            texture.destroyMethod = DestroyMethod.None;
            pCom.image.texture = texture;
        });
    }

    /// <summary> 暂停视频 </summary>
    public void PauseVideo()
    {
        if (videoCom != null)
        {
            videoCom.Pause();
        }
    }

    void LoadVideoAsset(string name, Action<AssetHandle> videoAH)
    {
        var package = YooAssets.GetPackage(AppConfig.defaultYooAssetPKG); //"DefaultPackage");
        var handle = package.LoadAssetAsync<VideoClip>(name);
        handle.Completed += videoAH;
    }

    public void ClearVideo()
    {
        if (videoHandle != null)
        {
            videoHandle.Release();
            videoHandle = null;
        }

        if (renderTexture != null)
        {
            RenderTexture.ReleaseTemporary(renderTexture);
            renderTexture = null;
        }

        if (videoGo != null)
        {
            GameObject.Destroy(videoGo);
            videoGo = null;
        }
    }
}