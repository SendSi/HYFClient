using System.Collections.Generic;
using Newtonsoft.Json;
using YooAsset;

/// <summary>
/// 使用_init_.bat进行全部导出,默认使用字典形式的json文件,右键_init_.bat打开可以添加用List形式导出
/// </summary>
// 默认使用字典模式     少使用array         导表还是使用 CfgLubanMgr吧,性能好一点...  这个一开始写出的...不打算用了,但也不删吧
public class CfgJsonMgr : Singleton<CfgJsonMgr>
{
    protected override void OnInit()
    {
        base.OnInit();
    }

    /// <summary> T是表类型    返回整个导表  TClass=(json名字_对象名字)</summary>
    public Dictionary<string, TClass> LoadConfigDics<TClass>()
    {
        string json = JsonFileString<TClass>();
        var infos = JsonConvert.DeserializeObject<Dictionary<string, TClass>>(json);
        return infos;
    }
    
    /// <summary>  TClass是表类型    返回整个导表  TClass=(对象名字)    jsonFileName=(json名字)</summary>
    public Dictionary<string, TClass> LoadConfigDics<TClass>(string jsonFileName)
    {
        string json = JsonFileString(jsonFileName);
        var infos = JsonConvert.DeserializeObject<Dictionary<string, TClass>>(json);
        return infos;
    }

    /// <summary> TClass是表类型    返回整个导表   TClass=(json名字_对象名字) </summary>
    public List<TClass> LoadConfigList<TClass>()
    {
        string json = JsonFileString<TClass>();
        var infos = JsonConvert.DeserializeObject<List<TClass>>(json);
        return infos;
    }

    /// <summary> TClass是表类型    返回整个导表   TClass=(对象名字)    jsonFileName=(json名字)</summary>
    public List<TClass> LoadConfigList<TClass>(string jsonFileName) 
    {
        string json = JsonFileString(jsonFileName);
        var infos = JsonConvert.DeserializeObject<List<TClass>>(json);
        return infos;
    }

    public TClass LoadConfigClass<TClass>(string jsonFileName)
    {
        string json = JsonFileString(jsonFileName);
        var dto = JsonConvert.DeserializeObject<TClass>(json);
        return dto;
    }
    

    /// <summary> T是表类型  value是表id  返回一行数据</summary>
    public T LoadConfigOne<T>(string key)
    {
        string json = JsonFileString<T>();
        var infos = JsonConvert.DeserializeObject<Dictionary<string, T>>(json);
        if (infos.TryGetValue(key, out var config))
        {
            return config;
        }

        return default(T); //空值
    }
    
    /// <summary> T是表类型  value是表id  返回一行数据</summary>
    public T LoadConfigOne<T>(string key,string jsonFileName)
    {
        string json = JsonFileString(jsonFileName);
        var infos = JsonConvert.DeserializeObject<Dictionary<string, T>>(json);
        if (infos.TryGetValue(key, out var config))
        {
            return config;
        }

        return default(T); //空值
    }
    

    private Dictionary<string, string> _dicTabString = new Dictionary<string, string>();

    /// <summary> 取出字典的jsonString </summary>
    private string JsonFileString<T>()
    {
        var name = (typeof(T).Name);
        return JsonFileString(name);
    }
    
    
    /// <summary> 取出字典的jsonString </summary>
    private string JsonFileString(string name)
    {
        string jsonStr = null;
        if (_dicTabString.TryGetValue(name, out jsonStr))
        {
            return jsonStr;
        }
        else
        {
            var assetPackage = YooAssets.TryGetPackage(AppConfig.defaultYooAssetPKG); //"DefaultPackage");
            var handle = assetPackage.LoadAssetSync(name);
            jsonStr = handle.AssetObject.ToString();
            _dicTabString[name] = jsonStr;
            return jsonStr;
        }
    }

    #region 哎 留着吧..不用了
    // private string _langCfgName; //翻译表  导表之间的索引
    // private string _langScriptName; //写代码时 收集的到表
    // _langCfgName = "Cfg_" + AppConfig.currLang; //翻译表  导表之间的索引   一般策划维护的表
    // _langScriptName = "Script_" + AppConfig.currLang; //写代码时 程序员 收集的到excel中去   后面也是策划维护的     
    
    // private Dictionary<string, Cfg_SimChinese> langCfgDic; //因为翻译索引表 都是一样字段  取哪个一样
    // public string GetCurrLangCfgTxt(string langId)
    // {
    //     if (langCfgDic == null)
    //     {
    //         var assetPackage = YooAssets.TryGetPackage(AppConfig.defaultYooAssetPKG);//"DefaultPackage");
    //         var handle = assetPackage.LoadAssetSync(_langCfgName);
    //         var jsonStr = handle.AssetObject.ToString();
    //         langCfgDic = JsonConvert.DeserializeObject<Dictionary<string, Cfg_SimChinese>>(jsonStr); //因为翻译索引表 都是一样字段  取哪个一样
    //     }
    //
    //     if (langCfgDic.TryGetValue(langId, out var idValue))
    //     {
    //         return idValue.name;
    //     }
    //     else
    //     {
    //         return "NULL";
    //     }
    // }
    //
    // private Dictionary<string, Script_SimChinese> langScriptDic; //因为翻译索引表 都是一样字段  取哪个一样
    // public string GetCurrLangScriptTxt(string langId)
    // {
    //     if (langScriptDic == null)
    //     {
    //         var assetPackage = YooAssets.TryGetPackage(AppConfig.defaultYooAssetPKG);//"DefaultPackage");
    //         var handle = assetPackage.LoadAssetSync(_langScriptName);
    //         var jsonStr = handle.AssetObject.ToString();
    //         langScriptDic = JsonConvert.DeserializeObject<Dictionary<string, Script_SimChinese>>(jsonStr); //因为翻译索引表 都是一样字段  取哪个一样
    //     }
    //
    //     if (langScriptDic.TryGetValue(langId, out var idValue))
    //     {
    //         return idValue.name;
    //     }
    //     else
    //     {
    //         return "NULL";
    //     }
    // }
    #endregion
}