﻿using System;
using CommonPKG;
using FairyGUI;

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
    public void AddToastId(string stringId)
    {
        var cfg = ConfigMgr.Instance.LoadConfigOne<TipTextConfig>(stringId);
        if (cfg != null)
        {
            AddToastStr(cfg.content);
        }
    }

    public void AddToastId(string stringId, params object[] args)
    {
        var cfg = ConfigMgr.Instance.LoadConfigOne<TipTextConfig>(stringId);
        if (cfg != null)
        {
            AddToastStr(string.Format(cfg.content, args));
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

    public void AddHorseLampId(string stringId)
    {
        var cfg = ConfigMgr.Instance.LoadConfigOne<TipTextConfig>(stringId);
        if (cfg != null)
        {
            AddHorseLampStr(cfg.content);
        }
    }

    public void AddHorseLampId(string stringId, params object[] args)
    {
        var cfg = ConfigMgr.Instance.LoadConfigOne<TipTextConfig>(stringId);
        if (cfg != null)
        {
            AddHorseLampStr(string.Format(cfg.content, args));
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