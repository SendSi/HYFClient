using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Newtonsoft.Json;
using UnityEngine;
using YooAsset;


//导表工具 默认使用字典模式     不使用array
public class ConfigMgr : Singleton<ConfigMgr>
{
    private string _langCfgName; //翻译表  导表之间的索引
    private string _langScriptName; //写代码时 收集的到表

    protected override void OnInit()
    {
        base.OnInit();
        _langCfgName = "Cfg_" + AppConfig.currLang; //翻译表  导表之间的索引
        _langScriptName = "Script_" + AppConfig.currLang; //写代码时 收集的到表
    }

    /// <summary> T是表类型    返回整个导表</summary>
    public Dictionary<string, T> LoadConfigDics<T>()
    {
        string json = JsonFileString<T>();
        var infos = JsonConvert.DeserializeObject<Dictionary<string, T>>(json);
        return infos;
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


    private Dictionary<string, string> _dicTabString = new Dictionary<string, string>();

    /// <summary> 取出字典的jsonString </summary>
    private string JsonFileString<T>()
    {
        string jsonStr = null;
        var name = (typeof(T).Name);
        if (_dicTabString.TryGetValue(name, out jsonStr))
        {
            return jsonStr;
        }
        else
        {
            var assetPackage = YooAssets.TryGetPackage("DefaultPackage");
            var handle = assetPackage.LoadAssetSync(name);
            jsonStr = handle.AssetObject.ToString();
            _dicTabString[name] = jsonStr;
            return jsonStr;
        }
    }


    private Dictionary<string, Cfg_SimChinese> langCfgDic; //因为翻译索引表 都是一样字段  取哪个一样
    public string GetCurrLangCfgTxt(string langId)
    {
        if (langCfgDic == null)
        {
            var assetPackage = YooAssets.TryGetPackage("DefaultPackage");
            var handle = assetPackage.LoadAssetSync(_langCfgName);
            var jsonStr = handle.AssetObject.ToString();
            langCfgDic = JsonConvert.DeserializeObject<Dictionary<string, Cfg_SimChinese>>(jsonStr);            //因为翻译索引表 都是一样字段  取哪个一样
        }

        if (langCfgDic.TryGetValue(langId, out var idValue))
        {
            return idValue.name;
        }
        else
        {
            return "NULL";
        }
    }
    
    
    private Dictionary<string, Script_SimChinese> langScriptDic; //因为翻译索引表 都是一样字段  取哪个一样
    public string GetCurrLangScriptTxt(string langId)
    {
        if (langScriptDic == null)
        {
            var assetPackage = YooAssets.TryGetPackage("DefaultPackage");
            var handle = assetPackage.LoadAssetSync(_langScriptName);
            var jsonStr = handle.AssetObject.ToString();
            langScriptDic = JsonConvert.DeserializeObject<Dictionary<string, Script_SimChinese>>(jsonStr);            //因为翻译索引表 都是一样字段  取哪个一样
      }
        if (langScriptDic.TryGetValue(langId, out var idValue))
        {
            return idValue.name;
        }
        else
        {
            return "NULL";
        }
    }


    // private Dictionary<string, Dictionary<string,T>> _dicTabString2 = new Dictionary<string, Dictionary<string,T>>();//不能这样定义
    // private Dictionary<string, Dictionary<string,object>> _dicTabString2 = new Dictionary<string, Dictionary<string,object>>();//装箱 折箱 ??
}