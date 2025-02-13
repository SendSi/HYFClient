using System;
using HitHamsterPKG;

public class ProxyHitHamsterPKGModule : Singleton<ProxyHitHamsterPKGModule>, IProxy
{
    private const string pkgName = "HitHamsterPKG";

    public void CheckLoad(Action finishCB)
    {
        FGUILoader.Instance.AddPackage(pkgName, finishCB);
    }


    #region HitHamsterMainView打开关闭View

    public void OpenHitHamsterMainView(int cfgId)
    {
        CheckLoad(() =>
        {
            var view = UIMgr.Instance.OpenUIViewCom<HitHamsterMainView>(pkgName);
            view.SetData(cfgId);
        });
    }

    public void CloseHitHamsterView()
    {
        UIMgr.Instance.CloseUIViewCom<HitHamsterMainView>();
    }

    #endregion
}