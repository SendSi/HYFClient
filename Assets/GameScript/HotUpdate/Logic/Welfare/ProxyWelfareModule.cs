using System;
using Welfare;

public class ProxyWelfareModule : Singleton<ProxyWelfareModule>,IProxy
{
    private const string pkgName = "Welfare";

    public void CheckLoad(Action finishCB)
    {
        FGUILoader.Instance.AddPackage(pkgName, finishCB);
    }

    #region WelfareMainView打开关闭View

    public void OpenWelfareMainView()
    {
        CheckLoad(() =>
        {
            UIMgr.Instance.OpenUIViewCom<WelfareMainView>(pkgName);
        });
    }

    public void CloseWelfareMainView()
    {
        UIMgr.Instance.CloseUIViewCom<WelfareMainView>();
    }

    #endregion
}