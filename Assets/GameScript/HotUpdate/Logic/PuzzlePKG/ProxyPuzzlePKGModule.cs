using PuzzlePKG;
using System;

public class ProxyPuzzlePKGModule : Singleton<ProxyPuzzlePKGModule>, IProxy
{
    private const string pkgName = "PuzzlePKG";

    public void CheckLoad(Action finishCB)
    {
        FGUILoader.Instance.AddPackage(pkgName, finishCB);
    }

    public void OpenPuzzleMainView()
    {
        CheckLoad(() =>
        {
            var targetView = UIMgr.Instance.OpenUIViewCom<PuzzleMainView>(pkgName);
            targetView.SetData("打开页面数据传递");
        });
    }
    public void ClosePuzzleMainView()
    {
        UIMgr.Instance.CloseUIViewCom<PuzzleMainView>();
    }
}
