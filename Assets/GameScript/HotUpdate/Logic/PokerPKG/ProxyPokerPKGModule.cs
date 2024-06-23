using PokerPKG;
using System;

public class ProxyPokerPKGModule : Singleton<ProxyPokerPKGModule>, IProxy
{
    private const string pkgName = "PokerPKG";

    public void CheckLoad(Action finishCB)
    {
        FGUILoader.Instance.AddPackage(pkgName, finishCB);
    }

    public void OpenPokerMainView()
    {
        CheckLoad(() =>
        {
            var targetView = UIMgr.Instance.OpenUIViewCom<PokerMainView>(pkgName);
            targetView.SetData("打开页面数据传递");
        });
    }
    public void ClosePokerMainView()
    {
        UIMgr.Instance.CloseUIViewCom<PokerMainView>();
    }
}
