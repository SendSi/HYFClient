using Luban;
using UnityEngine;
using YooAsset;
/// <summary>
/// https://luban.doc.code-philosophy.com/docs/beginner/quickstart
///单独取一条数据.oneCfg-->CfgLubanMgr.Instance.globalTab.TbItemConfig.Get(id);
///取一个整表.lists--> CfgLubanMgr.Instance.globalTab.TbEightGiftConfig.DataList   
/// </summary>
public class CfgLubanMgr : Singleton<CfgLubanMgr>
{
    private cfg.Tables _globalTab;

    protected override void OnInit()
    {
        base.OnInit();
        Debug.LogWarning($"导表文件 加载了lubanBytes文件夹的所有bytes  使用二进制读取,比json的性能好很多");
        _globalTab = new cfg.Tables(LoadByteBuf);
    }

    public cfg.Tables globalTab
    {
        get { return _globalTab; }
    } //不给set

    private static ByteBuf LoadByteBuf(string file)
    {
        var assetPackage = YooAssets.TryGetPackage(AppConfig.defaultYooAssetPKG);
        var handle = assetPackage.LoadAssetSync(file);
        if (handle.AssetObject is UnityEngine.TextAsset textAsset)
        {
            return new ByteBuf(textAsset.bytes);
        }
        return null;
    }

    /// <summary> 举例 </summary>
    /// var cfg = CfgLubanMgr.Instance.globalTab.TbReward.Get(10001);       Debug.LogFormat("{0}",cfg);
    public void ExampleMethod()
    {
        var cfg1 = _globalTab.TBATestItem.DataList[1];
        Debug.LogFormat("下标 item[1]:{0}", cfg1);

        foreach (var itT in _globalTab.TBATestItem.DataList)
        {
            Debug.Log($"列表  {itT.Name}   {itT.Price}");
        }

        var cfg2 = _globalTab.TBATestItem.Get(10001);
        Debug.LogFormat("根据id取值 data:{0}", cfg2);
    }
}