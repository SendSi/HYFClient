using System;
using AStarPKG;

public class ProxyAStarPKGModule : Singleton<ProxyAStarPKGModule>, IProxy
{
    private const string pkgName = "AStarPKG";

    public void CheckLoad(Action finishCB)
    {
        FGUILoader.Instance.AddPackage(pkgName, finishCB);
    }

    #region AStarView打开关闭View
    public void OpenAStarView()
    {
        CheckLoad(() => { UIMgr.Instance.OpenUIViewCom<AStarView>(pkgName); });
    }

    public void CloseAStarView()
    {
        UIMgr.Instance.CloseUIViewCom<AStarView>();
    }
    #endregion
}