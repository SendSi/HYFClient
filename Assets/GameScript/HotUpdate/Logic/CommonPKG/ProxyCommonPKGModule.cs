using System;
using CommonPKG;

public class ProxyCommonPKGModule : Singleton<ProxyCommonPKGModule>, IProxy
{
    private const string pkgName = "CommonPKG";

    public void CheckLoad(Action finishCB) { FGUILoader.Instance.AddPackage(pkgName, finishCB); }

    #region 飘字调用 ***AddToastStr()
    private ToastTipView _toastTipView;

    public void AddToastStr(string valueStr)
    {
        if (_toastTipView == null)
        {
            OpenToastTipView(valueStr);
        } else
        {
            _toastTipView.SetData(valueStr);
        }
    }

    private void OpenToastTipView(string valueStr)
    {
        CheckLoad(() =>
        {
            _toastTipView = UIMgr.Instance.OpenUIViewCom<ToastTipView>(pkgName);
            _toastTipView.SetData(valueStr);
        });
    }

    public void LoadToastTipView() { CheckLoad(() => { _toastTipView = UIMgr.Instance.OpenUIViewCom<ToastTipView>(pkgName); }); }
    #endregion

    public ToastTipView GetToastView() { return _toastTipView; }
}