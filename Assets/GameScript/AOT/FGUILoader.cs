using FairyGUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using YooAsset;

public class FGUILoader : Singleton<FGUILoader>
{
    private int mReleaseTime = 20; //当无引用时 多少秒后 释放
    private int mCurTimeNum = 0; //当前运行的时间

    /// <summary> 常驻包 不移除销毁的  依赖公共包 </summary>
    private readonly Dictionary<string, bool> mForeverPKG = new Dictionary<string, bool>()
    {
        ["CommonPKG"] = true,
        ["Emoji"] = true,
        ["ItemPKG"] = true,
    };

    protected override void OnInit()
    {
        base.OnInit();
        FairyGUI.Timers.inst.Add(1, -1, (cb) =>
        {
            mCurTimeNum += 1;
            CheckTimeReleasePKG();
        });
    }


    /// <summary> 已load出来的 fgui的package </summary>
    private Dictionary<string, UIPackage> mLoadedPKG = new Dictionary<string, UIPackage>();
    
    /// <summary> key=pkgName,,,,value=时间 </summary>
    private Dictionary<string, int> mReleasePKGDic = new Dictionary<string, int>();

    /// <summary> 已load出来的 yooAsset的package </summary>
    private Dictionary<string, List<AssetHandle>> mLoadedHandles = new Dictionary<string, List<AssetHandle>>();

    public void AddPackage(string pkgName, Action finishCB)
    {
        UIPackage pkgED = null;

        mReleasePKGDic.Remove(pkgName);
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
        TryAddHandles(pkgName, handle);

        Debug.LogWarning("加入_业务包:" + pkgName);
        var pkgDeep = GetDependencies(tUIPackage); //获得  此包的 依赖包   名字s
        GameMain.Instance.StartCoroutine(LoadDependencies(pkgDeep, finishCB)); //加载依赖包
    }


    private IEnumerator LoadUIExtensions(string package, string name, string extension, Type type,
        PackageItem packageItem)
    {
        var assetPackage = YooAssets.TryGetPackage("DefaultPackage");
        var handle = assetPackage.LoadAssetAsync($"{package}_{name}");
        yield return handle;
        packageItem.owner.SetItemAsset(packageItem, handle.AssetObject, DestroyMethod.None);
        TryAddHandles(package, handle);
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
                        TryAddHandles(pkgName, handle);
                        Debug.LogWarning("加入_依赖包:" + pkgName);
                    }
                    else
                    {
                        Debug.LogError("业务包 被当成 依赖包  加载了  注意制作UI-->" + pkgName + ",依赖包数=" + num);
                    }
                }

                if (i + 1 == num)
                    loaded?.Invoke();
            }
        }
        else
        {
            loaded?.Invoke();
        }
    }
    
    /// <summary> 加入 准备 释放队列中 </summary>
    public void RemoveUIPackage(string pkgName)
    {
        if (mForeverPKG.ContainsKey(pkgName) == false)
        {
            if (mLoadedPKG.ContainsKey(pkgName))
            {
                mReleasePKGDic[pkgName] = (mCurTimeNum + mReleaseTime);
                Debug.LogWarning($"{pkgName} 在 {mReleaseTime}秒内 再无引用 将被释放");
            }
        }
    }

    /// <summary>每秒计算一次</summary>
    private void CheckTimeReleasePKG()
    {
        for (int i = 0; i < mReleasePKGDic.Count; i++)
        {
            var item= mReleasePKGDic.ElementAt(i);
            if (item.Value <= mCurTimeNum)
            {
                UIPackage.RemovePackage(item.Key);
                mLoadedPKG.Remove(item.Key);
        
                ReleaseHandle(item.Key);
                Debug.LogWarning($"{item.Key} 释放了");
        
                mReleasePKGDic.Remove(item.Key);
            }
        }
    }


    //把公共包 都先load出来   之后使用ui://包名/图片名  就能正常了
    public void CheckLoadComPKG()
    {
        var list = new List<string>();
        foreach (var item in mForeverPKG)
        {
            list.Add(item.Key);
        }

        GameMain.Instance.StartCoroutine(LoadDependencies(list, null)); //加载 依赖公共包
    }


    void TryAddHandles(string pkgName, AssetHandle ah)
    {
        List<AssetHandle> tHandle = null;
        if (mLoadedHandles.TryGetValue(pkgName, out tHandle))
        {
            tHandle.Add(ah);
        }
        else
        {
            tHandle = new List<AssetHandle>() { ah };
            mLoadedHandles[pkgName] = tHandle;
        }
    }

    void ReleaseHandle(string pkgName)
    {
        List<AssetHandle> tHandle = null;
        if (mLoadedHandles.TryGetValue(pkgName, out tHandle))
        {
            foreach (var handle in tHandle)
            {
                handle.Release();
            }

            tHandle.Clear();
        }
    }
}