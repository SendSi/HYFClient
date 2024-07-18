using System;
using CommonPKG;
using FairyGUI;
using cfg;

public class ProxyCommonPKGModule : Singleton<ProxyCommonPKGModule>, IProxy
{
    private const string pkgName = "CommonPKG";

    public void CheckLoad(Action finishCB)
    {
        FGUILoader.Instance.AddPackage(pkgName, finishCB);
    }

    #region 飘字调用 ***AddToastStr() or AddToastId()

    private ToastTipView _toastTipView;

    public void AddToastStr(string valueStr)
    {
        if (_toastTipView == null)
        {
            OpenToastTipView(valueStr);
        }
        else
        {
            _toastTipView.SetFloatTip(valueStr);
        }
    }

    //使用string的id咯,省去装拆箱
    public void AddToastId(int keyId)
    {
        // var cfg = ConfigMgr.Instance.LoadConfigOne<TipTextConfig>(stringId);
        var cfg = CfgLubanMgr.Instance.globalTab.TbTipTextConfig.Get(keyId);
        if (cfg != null)
        {
            AddToastStr(cfg.Content);
        }
    }

    public void AddToastId(int keyId, params object[] args)
    {
        // var cfg = ConfigMgr.Instance.LoadConfigOne<TipTextConfig>(stringId);
        var cfg = CfgLubanMgr.Instance.globalTab.TbTipTextConfig.Get(keyId);
        if (cfg != null)
        {
            AddToastStr(string.Format(cfg.Content, args));
        }
    }

    private void OpenToastTipView(string valueStr)
    {
        CheckLoad(() =>
        {
            _toastTipView = UIMgr.Instance.OpenUIViewCom<ToastTipView>(pkgName);
            _toastTipView.SetFloatTip(valueStr);
        });
    }

    public void LoadToastTipView()
    {
        CheckLoad(() => { _toastTipView = UIMgr.Instance.OpenUIViewCom<ToastTipView>(pkgName); });
    }

    #endregion

    public ToastTipView GetToastView()
    {
        return _toastTipView;
    }

    #region 跑马灯调用 ***AddHorseLampId() or AddHorseLampStr()

    public void AddHorseLampId(int keyId)
    {
        // var cfg = ConfigMgr.Instance.LoadConfigOne<TipTextConfig>(stringId);
        var cfg = CfgLubanMgr.Instance.globalTab.TbTipTextConfig.Get(keyId);
        if (cfg != null)
        {
            AddHorseLampStr(cfg.Content);
        }
    }

    public void AddHorseLampId(int keyId, params object[] args)
    {
        // var cfg = ConfigMgr.Instance.LoadConfigOne<TipTextConfig>(stringId);
        var cfg = CfgLubanMgr.Instance.globalTab.TbTipTextConfig.Get(keyId);
        if (cfg != null)
        {
            AddHorseLampStr(string.Format(cfg.Content, args));
        }
    }

    private void AddHorseLampStr(string valueStr)
    {
        if (_toastTipView == null)
        {
            CheckLoad(() =>
            {
                _toastTipView = UIMgr.Instance.OpenUIViewCom<ToastTipView>(pkgName);
                _toastTipView.SetHorseLamp(valueStr);
            });
        }
        else
        {
            _toastTipView.SetHorseLamp(valueStr);
        }
    }

    #endregion

    GObject popItem1;
    public void ShowPopupItem1(GObject target,ItemProp cfg)
    {
        if (popItem1 == null)
            popItem1 = FairyGUI.UIPackage.CreateObject("CommonPKG", "Item_Popup1");

        (popItem1 as Item_Popup1).SetData(cfg);//Item_Popup1.cs
        FairyGUI.GRoot.inst.ShowPopup(popItem1, target, PopupDirection.Auto);
    }
}