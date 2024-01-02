using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using YooAsset;


//导表工具 默认使用字典模式     不使用array
//真正apk 到时应该把其打成ab包的  再看看怎么加载吧
public class ConfigMgr : BaseInstance<ConfigMgr>
{
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

    // private Dictionary<string, Dictionary<string,T>> _dicTabString2 = new Dictionary<string, Dictionary<string,T>>();//不能这样定义
    // private Dictionary<string, Dictionary<string,object>> _dicTabString2 = new Dictionary<string, Dictionary<string,object>>();//装箱 折箱 ??
}