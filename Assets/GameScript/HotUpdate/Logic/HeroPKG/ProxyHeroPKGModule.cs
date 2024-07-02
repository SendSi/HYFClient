#region << 脚 本 注 释 >>
//作  用:    ProxySpinePKGModule
//作  者:    曾思信
//创建时间:  #CREATETIME#
#endregion

using System;
using HeroPKG;

public  class ProxyHeroPKGModule :Singleton<ProxyHeroPKGModule>, IProxy
{
    private const string pkgName = "HeroPKG";

    public void CheckLoad(Action finishCB)
    {
        FGUILoader.Instance.AddPackage(pkgName, finishCB);
    }
    
    
    #region HeroInfoView打开关闭View
    public void OpenHeroInfoView(int cfgId)
    {
        CheckLoad(() =>
        {
            var view = UIMgr.Instance.OpenUIViewCom<HeroInfoView>(pkgName);
            view.SetData(cfgId);
        });
    }

    public void CloseHeroInfoView()
    {
        UIMgr.Instance.CloseUIViewCom<HeroInfoView>();
    }
    #endregion

}