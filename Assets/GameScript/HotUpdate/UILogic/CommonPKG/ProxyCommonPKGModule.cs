using System;
using CommonPKG;


public class ProxyCommonPKGModule : BaseInstance<ProxyCommonPKGModule>, IProxy
{
    private const string pkgName = "CommonPKG";

    public void CheckLoad(Action finishCB)
    {
        FGUILoader.GetInstance().AddPackage(pkgName, finishCB);
    }


    #region 飘字调用 ***AddToastStr()

    private ToastTipView _toastTipView;

    public void AddToastStr(string valueStr)
    {
        if (_toastTipView == null)
        {
            OpenToastTipView(valueStr);
        }
        else
        {
            _toastTipView.SetData(valueStr);
        }
    }

    private void OpenToastTipView(string valueStr)
    {
        CheckLoad(() =>
        {
            _toastTipView = UIMgr.GetInstance().OpenUIViewCom<ToastTipView>(pkgName);
            _toastTipView.SetData(valueStr);
        });
    }

    #endregion
}
