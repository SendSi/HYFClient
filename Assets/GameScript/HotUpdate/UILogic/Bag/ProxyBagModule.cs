using System;
using Bag;


public class ProxyBagModule : Singleton<ProxyBagModule>
{
    private const string pkgName = "Bag";

    public void CheckLoad(Action finishCB)
    {
        FGUILoader.Instance.AddPackage(pkgName, finishCB);
    }


    #region BagMainView打开关闭View

    public void OpenBagMainView()
    {
        CheckLoad(() => { UIMgr.Instance.OpenUIViewCom<BagMainView>(pkgName); });
    }

    public void CloseBagMainView()
    {
        UIMgr.Instance.CloseUIViewCom<BagMainView>();
    }

    #endregion


    #region BagComposeView打开关闭Window

    public void OpenBagComposeViewWin()
    {
        CheckLoad(() => { UIMgr.Instance.OpenWindow<BagComposeViewWin>(); });
    }

    public void CloseBagComposeViewWin()
    {
        UIMgr.Instance.CloseWindow<BagComposeViewWin>();
    }

    #endregion
}
