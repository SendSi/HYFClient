using System;
using Login;

public class ProxyLoginModule : Singleton<ProxyLoginModule>,IProxy
{
    private const string pkgName = "Login";
    public void CheckLoad(Action finishCB)
    {
        FGUILoader.Instance.AddPackage(pkgName, finishCB);
    }


    public void OpenLoginMainView()
    {
        CheckLoad(() =>
        {
            var targetView = UIMgr.Instance.OpenUIViewCom<LoginMainView>("Login");
            targetView.SetData("打开页面数据传递");
        });
    }

    public void CloseLoginMainView()
    {
        UIMgr.Instance.CloseUIViewCom<LoginMainView>();
    }



    #region GameAgeView打开关闭Window

    public void OpenGameAgeViewWin()
    {
        CheckLoad(() => { UIMgr.Instance.OpenWindow<GameAgeViewWin>(); });
    }

    public void CloseGameAgeViewWin()
    {
        UIMgr.Instance.CloseWindow<GameAgeViewWin>();
    }

    #endregion

    #region GameNoticeView打开关闭Window

    public void OpenGameNoticeViewWin()
    {
        CheckLoad(() => { UIMgr.Instance.OpenWindow<GameNoticeViewWin>(); });
    }

    public void CloseGameNoticeViewWin()
    {
        UIMgr.Instance.CloseWindow<GameNoticeViewWin>();
    }

    #endregion

    #region ServerListDetailView打开关闭Window

    public void OpenServerListDetailViewWin()
    {
        CheckLoad(() => { UIMgr.Instance.OpenWindow<ServerListDetailViewWin>(); });
    }

    public void CloseServerListDetailViewWin()
    {
        UIMgr.Instance.CloseWindow<ServerListDetailViewWin>();
    }

    #endregion

    #region ServerListRemoteView打开关闭Window

    public void OpenServerListRemoteViewWin()
    {
        CheckLoad(() => { UIMgr.Instance.OpenWindow<ServerListRemoteViewWin>(); });
    }

    public void CloseServerListRemoteViewWin()
    {
        UIMgr.Instance.CloseWindow<ServerListRemoteViewWin>();
    }

    #endregion

}
