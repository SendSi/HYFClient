using System;


public class ProxyGMModule : Singleton<ProxyGMModule>
{
    private const string pkgName = "GMView";

    public void CheckLoad(Action finishCB)
    {
        FGUILoader.Instance.AddPackage(pkgName, finishCB);
    }
    
    
    #region GMMainView打开关闭View

    public void OpenGMMainView()
    {
        CheckLoad(() => { UIMgr.Instance.OpenUIViewCom<GMView.GMMainView>(pkgName); });
    }

    public void CloseGMMainView()
    {
        UIMgr.Instance.CloseUIViewCom<GMView.GMMainView>();
    }

    #endregion
}