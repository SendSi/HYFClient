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
        Debug.Log("AAAA");
        if (SceneDic.TryGetValue(sceneId, out SceneBase newScene))
        {
            if (await newScene.Init(mapId,backScene))
            {
                Debug.Log("BBB");
                newScene.EnterScene();
                ProxyCommonPKGModule.Instance.CloseLoadingView();
            }
        }
    }
}