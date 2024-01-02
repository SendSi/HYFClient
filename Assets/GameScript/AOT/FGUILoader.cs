using FairyGUI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YooAsset;

public class FGUILoader : BaseInstance<FGUILoader>
{
    /// <summary> 常驻包 不移除销毁的 </summary>
    private readonly Dictionary<string, bool> mForeverPKG = new Dictionary<string, bool>()
    {
        ["CommonPKG"] = true,
        ["Emoji"] = true,
        ["ItemPKG"] = true,
    };


    /// <summary> 已load出来的 fgui的package </summary>
    private Dictionary<string, UIPackage> mLoadedPKG = new Dictionary<string, UIPackage>();
    /// <summary> 已load出来的 yooAsset的package </summary>
    private Dictionary<string, AssetHandle> mLoadedHandle = new Dictionary<string, AssetHandle>();

    public void AddPackage(string pkgName, Action finishCB)
    {
        UIPackage pkgED = null;
        if (mLoadedPKG.TryGetValue(pkgName, out pkgED))
        {
            finishCB?.Invoke();
            return;
        }

        GameMain.Instance.StartCoroutine(LoadUIPackage(pkgName, () => { finishCB?.Invoke(); }));
    }


    public IEnumerator LoadUIPackage(string pkgName, Action finishCB)
    {
        var assetPackage = YooAssets.TryGetPackage("DefaultPackage");
        var handle = assetPackage.LoadAssetAsync<TextAsset>($"{pkgName}_fui");
        yield return handle;
        var pkgDesc = handle.AssetObject as TextAsset;
        var tUIPackage = UIPackage.AddPackage(pkgDesc.bytes, string.Empty,
            (name, extension, type, packageItem) =>
            {
                GameMain.Instance.StartCoroutine(LoadUIExtensions(pkgName, name, extension, type, packageItem));
            });
        tUIPackage.LoadAllAssets();

        mLoadedPKG[pkgName] = tUIPackage; //加入字典
        mLoadedHandle[pkgName] = handle;
        Debug.LogWarning("加入_业务包:" + pkgName);
        var pkgDeep = GetDependencies(tUIPackage);//获得  此包的 依赖包   名字s
        GameMain.Instance.StartCoroutine(LoadDependencies(pkgDeep, finishCB));//加载依赖包
    }

    private IEnumerator LoadUIExtensions(string package, string name, string extension, Type type, PackageItem packageItem)
    {
        var assetPackage = YooAssets.TryGetPackage("DefaultPackage");
        var targetObj = assetPackage.LoadAssetAsync($"{package}_{name}");
        yield return targetObj;
        packageItem.owner.SetItemAsset(packageItem, targetObj.AssetObject, DestroyMethod.None);
    }


    /// <summary>获得  此包的 依赖包   名字s</summary>
    private List<string> GetDependencies(UIPackage pkgName)
    {
        var tDependencies = pkgName.dependencies;
        var num = tDependencies.Length;
        var list = new List<string>();
        for (int i = 0; i < num; i++)
        {
            var depPackageName = tDependencies[i]["name"]; //依赖包
            list.Add(depPackageName);
        }
        return list;
    }

    /// <summary> 加载依赖包 </summary>
    private IEnumerator LoadDependencies(List<string> pkgDeep, Action loaded)
    {
        var num = pkgDeep.Count;
        if (num > 0)
        {
            for (int i = 0; i < num; i++)
            {
                var pkgName = pkgDeep[i]; // 依赖包
                if (mLoadedPKG.ContainsKey(pkgName) == false)
                {
                    if (mForeverPKG.ContainsKey(pkgName))
                    {
                        var assetPackage = YooAssets.TryGetPackage("DefaultPackage");
                        var handle = assetPackage.LoadAssetAsync<TextAsset>($"{pkgName}_fui");
                        yield return handle;
                        var pkgDesc = handle.AssetObject as TextAsset;
                        var tUIPackage = UIPackage.AddPackage(pkgDesc.bytes, string.Empty,
                            (name, extension, type, packageItem) =>
                            {
                                GameMain.Instance.StartCoroutine(LoadUIExtensions(pkgName, name, extension, type,
                                    packageItem));
                            });
                        tUIPackage.LoadAllAssets();

                        mLoadedPKG[pkgName] = tUIPackage;
                        mLoadedHandle[pkgName] = handle;
                        Debug.LogWarning("加入_依赖包:" + pkgName);
                    }
                    else
                    {
                        Debug.LogError("业务包 被当成 依赖包  加载了  注意制作UI-->" + pkgName + ",依赖包数=" + num);
                    }
                }

                if (i + 1 == num)
                    loaded.Invoke();
            }
        }
        else
        {
            loaded?.Invoke();
        }
    }

    public void RemoveUIPackage(string pkgName)
    {
        if (mForeverPKG.ContainsKey(pkgName) == false)
        {
            if (mLoadedPKG.ContainsKey(pkgName))
            {
                UIPackage.RemovePackage(pkgName);
                mLoadedPKG.Remove(pkgName);
                mLoadedHandle[pkgName].Release();
                Debug.LogWarning("移除包: " + pkgName + ",          后续加个定时器?多少秒内再不用 就真RemovePackage吧");
            }
        }
    }
}