using BitBenderGames;
using UnityEngine;

/// <summary>
/// 场景管理器
/// </summary>
public class SceneMgr : Singleton<SceneMgr>
{
    protected override void OnInit()
    {
        base.OnInit();
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            mainCamera.gameObject.GetOrAddComponent<TouchInputController>();
            mainCamera.gameObject.GetOrAddComponent<MobileTouchCamera>();
        }
        else
        {
            Debug.LogError("场景中未找到带有 MainCamera 标签的相机！");
        }
    }

    protected override void OnDispose()
    {
        base.OnDispose();
    }
}