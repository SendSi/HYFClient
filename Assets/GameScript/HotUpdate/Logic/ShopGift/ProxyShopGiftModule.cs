using System;
using ShopGift;
#region << 脚 本 注 释 >>
//作  用:    ProxyShopGiftModule
//作  者:    曾思信
//创建时间:  #CREATETIME#
#endregion
public class ProxyShopGiftModule : Singleton<ProxyShopGiftModule>,IProxy
{
    private const string pkgName = "ShopGift";

    public void CheckLoad(Action finishCB)
    {
        FGUILoader.Instance.AddPackage(pkgName, finishCB);
    }
    
    
    #region WelfareMainView打开关闭View

    public void OpenShopGiftMainView(int cfgId)
    {
        CheckLoad(() =>
        {
            var view = UIMgr.Instance.OpenUIViewCom<ShopGiftMainView>(pkgName);
            view.SetData(cfgId);
        });
    }

    public void CloseShopGiftMainView()
    {
        UIMgr.Instance.CloseUIViewCom<ShopGiftMainView>();
    }

    #endregion
    
}