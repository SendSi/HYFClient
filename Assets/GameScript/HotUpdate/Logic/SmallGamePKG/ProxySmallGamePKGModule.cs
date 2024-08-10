using System;
using SmallGamePKG;

public class ProxySmallGamePKGModule : Singleton<ProxySmallGamePKGModule>, IProxy
{
    private const string pkgName = "SmallGamePKG";

    public void CheckLoad(Action finishCB)
    {
        FGUILoader.Instance.AddPackage(pkgName, finishCB);
    }


    #region HamsterGameView打开关闭View

    public void OpenHamsterGameView(int cfgId)
    {
        CheckLoad(() =>
        {
            var view = UIMgr.Instance.OpenUIViewCom<HamsterGameView>(pkgName);
            view.SetData(cfgId);
        });
    }

    public void CloseHamsterGameView()
    {
        UIMgr.Instance.CloseUIViewCom<HamsterGameView>();
    }

    #endregion
}