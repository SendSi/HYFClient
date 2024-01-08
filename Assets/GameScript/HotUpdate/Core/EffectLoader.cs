using System;
using System.Collections.Generic;
using FairyGUI;
using UnityEngine;
using YooAsset;

public class EffectLoader : Singleton<EffectLoader>
{
    private List<EffectObject> mEffectObjs = new List<EffectObject>();

    /// <summary> 加载特效 </summary>
    /// <param name="actionCB">返回一个特效  EffectObject</param>
    public void LoadUIEffect(string effName, GComponent parent, Action<EffectObject> actionCB = null, float posX = 0f, float posY = 0f, float sizeX = 1f, float sizeY = 1f)
    {
        var handle = YooAssets.LoadAssetAsync<GameObject>(effName);
        handle.Completed += (AssetHandle actGO) =>
        {
            var instGO = actGO.InstantiateSync();
            var eObj = new EffectObject(handle, instGO, parent, posX, posY, sizeX, sizeY);
            mEffectObjs.Add(eObj);
            actionCB?.Invoke(eObj);
        };
    }

    public void Dispose(EffectObject effObj)
    {
        if (effObj != null)
        {
            effObj.Dispose();
            mEffectObjs.Remove(effObj);
        }
    }


    public void Clear()
    {
        foreach (var item in mEffectObjs)
        {
            item.Dispose(); //能用foreach?
        }

        mEffectObjs.Clear();
    }
}

public class EffectObject
{
    public AssetHandle handle { get; set; }
    public GameObject instGo { get; set; }
    public GGraph gGraph { get; set; }

    public EffectObject(AssetHandle tAH, GameObject tGo, GComponent parent, float posX, float posY, float sizeX, float sizeY)
    {
        handle = tAH;
        instGo = tGo;

        gGraph = new GGraph();
        var wrapper = new GoWrapper(tGo);
        gGraph.SetNativeObject(wrapper);
        parent.AddChild(gGraph);
        gGraph.SetXY(posX, posY);
        gGraph.SetSize(sizeX, sizeY);
    }

    public void Dispose()
    {
        if (handle != null)
        {
            handle.Release();
        }

        if (instGo != null)
        {
            GameObject.Destroy(instGo);
        }

        if (gGraph != null)
        {
            gGraph.Dispose();
        }
    }
}