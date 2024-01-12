using DialogTip;
using System;

public class ProxyDialogTipModule : Singleton<ProxyDialogTipModule>,IProxy
{
    private const string pkgName = "DialogTip";

    public void CheckLoad(Action finishCB)
    {
        FGUILoader.Instance.AddPackage(pkgName, finishCB);
    }

    #region DialogTip1View打开关闭Window

    public void OpenDialogTip1ViewWin(string title, string content, string btnTitle, Action sureCB)
    {
        CheckLoad(() =>
        {
            var view = UIMgr.Instance.OpenWindow<DialogTip1ViewWin>();
            view.SetData(title, content, btnTitle, sureCB);
        });
    }

    public void CloseDialogTip1ViewWin()
    {
        UIMgr.Instance.CloseWindow<DialogTip1ViewWin>();
    }

    #endregion


    #region DialogTip2View打开关闭Window  默认左边取消  右边确定

    public void OpenDialogTip2ViewWin(string title, string content, string leftBtnTitle, Action leftCB,string rightBtnTitle,Action rightCB)
    {
        leftBtnTitle = string.IsNullOrEmpty(leftBtnTitle) ? "取消" : leftBtnTitle;
        rightBtnTitle = string.IsNullOrEmpty(rightBtnTitle) ? "确定" : rightBtnTitle;
        CheckLoad(() =>
        {
            var view = UIMgr.Instance.OpenWindow<DialogTip2ViewWin>();
            view.SetData(title, content, leftBtnTitle, leftCB,rightBtnTitle,rightCB);
        });
    }

    public void CloseDialogTip2ViewWin()
    {
        UIMgr.Instance.CloseWindow<DialogTip2ViewWin>();
    }

    #endregion
}
