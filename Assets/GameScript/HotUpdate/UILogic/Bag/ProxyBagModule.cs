using System;
using Bag;


public class ProxyBagModule : BaseInstance<ProxyBagModule>
{
    private const string pkgName = "Bag";

    public void CheckLoad(Action finishCB)
    {
        FGUILoader.GetInstance().AddPackage(pkgName, finishCB);
    }


    #region BagMainView打开关闭View

    public void OpenBagMainView()
    {
        CheckLoad(() => { UIMgr.GetInstance().OpenUIViewCom<BagMainView>(pkgName); });
    }

    public void CloseBagMainView()
    {
        UIMgr.GetInstance().CloseUIViewCom<BagMainView>();
    }

    #endregion


    #region BagComposeView打开关闭Window

    public void OpenBagComposeViewWin()
    {
        CheckLoad(() => { UIMgr.GetInstance().OpenWindow<BagComposeViewWin>(); });
    }

    public void CloseBagComposeViewWin()
    {
        UIMgr.GetInstance().CloseWindow<BagComposeViewWin>();
    }

    #endregion
}
