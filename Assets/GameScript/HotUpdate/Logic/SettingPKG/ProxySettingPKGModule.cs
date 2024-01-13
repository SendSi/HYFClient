using System;
using GMView;

public class ProxySettingPKGModule : Singleton<ProxySettingPKGModule>
{
    private const string pkgName = "SettingPKG";

    public void CheckLoad(Action finishCB) { FGUILoader.Instance.AddPackage(pkgName, finishCB); }

    #region SettingMainViewWin打开关闭View
    public void OpenSettingPKGViewWin()
    {
        CheckLoad(() => { UIMgr.Instance.OpenWindow<SettingMainViewWin>(); });
    }

    public void CloseSettingPKGViewWin() { UIMgr.Instance.HideUIViewCom<GMMainView>(); }
    #endregion
}