using Luban;
using UnityEngine;
using YooAsset;

public class CfgLubanMgr : Singleton<CfgLubanMgr>
{
    protected override void OnInit()
    {
        base.OnInit();

        var tables = new cfg.Tables(LoadByteBuf);
        var item = tables.TbItem.DataList[1];
        Debug.LogFormat("item[1]:{0}", item);
        foreach (var itT in tables.TbItem.DataList)
        {
            Debug.Log($"{itT.Name}   {itT.Price}");
        }

        var refv = tables.TbItem.DataList[0].Name;
        Debug.LogFormat("refv:{0}", refv);

        Debug.LogError("== 初始化 luban ==");

        // var data= tables.TbReward.Get(10001);
        // Debug.LogError(data.Name+"   "+data.Desc);
    }

    private static ByteBuf LoadByteBuf(string file)
    {
        Debug.LogError($"file={file}");
        var assetPackage = YooAssets.TryGetPackage(AppConfig.defaultYooAssetPKG);
        var handle = assetPackage.LoadAssetSync(file);
        if (handle.AssetObject is UnityEngine.TextAsset textAsset)
        {
            return new ByteBuf(textAsset.bytes);
        }

        return null;
    }

    // public T TT(string name) where T : new()
    // {
    //     var t = new T(LoadByteBuf(name));
    //     return t;
    // }

    public void Show()
    {
    }
}