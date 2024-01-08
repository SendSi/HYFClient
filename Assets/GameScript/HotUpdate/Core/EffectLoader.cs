using System;
using System.Collections.Generic;
using FairyGUI;
using UnityEngine;
using YooAsset;

public class EffectLoader : Singleton<EffectLoader>
{
    private Dictionary<string, AssetHandle> _handlesYooDic = new Dictionary<string, AssetHandle>();
    private Dictionary<string, GameObject> _handlesGoDic = new Dictionary<string, GameObject>();

    //返回的是guid
    public string LoadUIEffect(string effName, GComponent parent, float x = 0f, float y = 0f)
    {
        var guid = Guid.NewGuid().ToString();

        var handle = YooAssets.LoadAssetAsync<GameObject>(effName);

        handle.Completed += (AssetHandle actGO) =>
        {
            var instGO = actGO.InstantiateSync();
            var wrapper = new GoWrapper(instGO);
            var gGraph = new GGraph();
            gGraph.SetNativeObject(wrapper);

            parent.AddChild(gGraph);
            gGraph.SetXY(x, y);

            _handlesGoDic[guid] = instGO;
        };

        _handlesYooDic[guid] = handle;

        return guid;
    }


    public void Dispose(string guId)
    {
        if (_handlesYooDic.TryGetValue(guId, out var handle))
        {
            handle.Release();
        }

        if (_handlesGoDic.TryGetValue(guId, out var go))
        {
            GameObject.Destroy(go);
        }

        _handlesGoDic.Remove(guId);
        _handlesYooDic.Remove(guId);
    }
    
    

    public void Clear()
    {
        foreach (var item in _handlesYooDic)
        {
            item.Value.Release(); //能用foreach?
        }

        _handlesYooDic.Clear();
    }
}