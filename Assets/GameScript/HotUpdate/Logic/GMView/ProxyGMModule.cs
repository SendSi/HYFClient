using System;
using GMView;


public class ProxyGMModule : Singleton<ProxyGMModule>
{
    private const string pkgName = "GMView";

    public void CheckLoad(Action finishCB)
    {
        FGUILoader.Instance.AddPackage(pkgName, finishCB);
    }


    #region GMMainView打开关闭View

    private GMMainView _gmView;

    public void OpenGMMainView()
    {
        //若有引用 就显示咯 
        if (_gmView == null)
        {
            CheckLoad(() => { _gmView = UIMgr.Instance.OpenUIViewCom<GMMainView>(pkgName); });
        }
        else
        {
            UIMgr.Instance.ShowUIViewCom<GMMainView>();
        }
    }

    public void HideGMMainView()
    {
        if (_gmView!=null)
        {
            UIMgr.Instance.HideUIViewCom<GMMainView>();
        }
    }

    #endregion
}