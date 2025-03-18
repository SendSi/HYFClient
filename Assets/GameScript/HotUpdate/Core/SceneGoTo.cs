using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class SceneGoTo:Singleton<SceneGoTo>
{
    private Dictionary<int, SceneBase> SceneDic = new Dictionary<int, SceneBase>()
    {
        { 1001, new MainCityScene() },
    };

    public async UniTaskVoid EnterScene(int mapId, int sceneId = 1001, bool backScene = false)
    {
        ProxyCommonPKGModule.Instance.OpenLoadingView();
        Debug.Log("进度 1");
        if (SceneDic.TryGetValue(sceneId, out SceneBase newScene))
        {
            if (await newScene.Init(mapId,backScene))
            {
                newScene.EnterScene();
                await UniTask.Delay(TimeSpan.FromSeconds(1.1f)); //假的
                Debug.Log("进度 2");
                ProxyCommonPKGModule.Instance.CloseLoadingView();
            }
        }
    }
}