using System;
using Login;

public class ProxyLoginModule : BaseInstance<ProxyLoginModule>,IProxy
{
    private const string pkgName = "Login";
    public void CheckLoad(Action finishCB)
    {
        FGUILoader.GetInstance().AddPackage(pkgName, finishCB);
    }


    public void OpenLoginMainView()
    {
        CheckLoad(() =>
        {
            var targetView = UIMgr.GetInstance().OpenUIViewCom<LoginMainView>("Login");
            targetView.SetData("打开页面数据传递");
        });
    }

    public void CloseLoginMainView()
    {
        UIMgr.GetInstance().CloseUIViewCom<LoginMainView>();
    }



    #region GameAgeView打开关闭Window

    public void OpenGameAgeViewWin()
    {
        CheckLoad(() => { UIMgr.GetInstance().OpenWindow<GameAgeViewWin>(); });
    }

    public void CloseGameAgeViewWin()
    {
        UIMgr.GetInstance().CloseWindow<GameAgeViewWin>();
    }

    #endregion

    #region GameNoticeView打开关闭Window

    public void OpenGameNoticeViewWin()
    {
        CheckLoad(() => { UIMgr.GetInstance().OpenWindow<GameNoticeViewWin>(); });
    }

    public void CloseGameNoticeViewWin()
    {
        UIMgr.GetInstance().CloseWindow<GameNoticeViewWin>();
    }

    #endregion

    #region ServerListDetailView打开关闭Window

    public void OpenServerListDetailViewWin()
    {
        CheckLoad(() => { UIMgr.GetInstance().OpenWindow<ServerListDetailViewWin>(); });
    }

    public void CloseServerListDetailViewWin()
    {
        UIMgr.GetInstance().CloseWindow<ServerListDetailViewWin>();
    }

    #endregion

    #region ServerListRemoteView打开关闭Window

    public void OpenServerListRemoteViewWin()
    {
        CheckLoad(() => { UIMgr.GetInstance().OpenWindow<ServerListRemoteViewWin>(); });
    }

    public void CloseServerListRemoteViewWin()
    {
        UIMgr.GetInstance().CloseWindow<ServerListRemoteViewWin>();
    }

    #endregion

}
