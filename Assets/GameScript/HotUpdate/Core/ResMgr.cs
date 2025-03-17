using Cysharp.Threading.Tasks;
using YooAsset;

public class ResMgr : Singleton<ResMgr>
{
    
    public async UniTask<TObject> LoadAssetAsync<TObject>(string location) where TObject : UnityEngine.Object
    {
        var obj = UnityPool.Get<TObject>(location);
        if (obj != null)
        {
            return obj;
        }
        var handle = YooAssets.LoadAssetAsync<TObject>(location);

        return await _LoadAssetAsync<TObject>(location, handle);
    }
    
    async UniTask<TObject> _LoadAssetAsync<TObject>(string location, AssetHandle handle) where TObject : UnityEngine.Object
    {
        await handle.ToUniTask();
        var obj = handle.GetAssetObject<TObject>();
        if (obj is UnityEngine.GameObject)
        {
            var insHandle = handle.InstantiateAsync();
            await insHandle.ToUniTask();
            var ins = insHandle.Result;
            ins.AddComponent<ResHandleMono>().Init(location, handle);
            return ins as TObject;
        }

        using (handle)
        {
            return obj;
        }
    }
    
    
    public TObject LoadAsset<TObject>(string location) where TObject : UnityEngine.Object
    {
        var obj = UnityPool.Get<TObject>(location);
        if (obj != null)
        {
            return obj;
        }

        var handle = YooAssets.LoadAssetSync<TObject>(location);
        return _LoadAsset<TObject>(location, handle);
    }
    TObject _LoadAsset<TObject>(string location, AssetHandle handle) where TObject : UnityEngine.Object
    {
        var obj = handle.GetAssetObject<TObject>();
        if (obj is UnityEngine.GameObject)
        {
            var ins = handle.InstantiateSync();
            ins.AddComponent<ResHandleMono>().Init(location, handle);
            return ins as TObject;
        }

        using (handle)
        {
            return obj;
        }
    }
}