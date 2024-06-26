#region << 脚 本 注 释 >>
//作  用:    ProxySpinePKGModule
//作  者:    曾思信
//创建时间:  #CREATETIME#
#endregion

using System;
using SpinePKG;

public  class ProxySpinePKGModule :Singleton<ProxySpinePKGModule>, IProxy
{
    private const string pkgName = "SpinePKG";

    public void CheckLoad(Action finishCB)
    {
        FGUILoader.Instance.AddPackage(pkgName, finishCB);
    }
    
    
    #region SpineMainView打开关闭View

    public void OpenSpineMainView(string cfgId)
    {
        CheckLoad(() =>
        {
            var view = UIMgr.Instance.OpenUIViewCom<SpineMainView>(pkgName);
            view.SetData(cfgId);
        });
    }

    public void CloseSpineMainView()
    {
        UIMgr.Instance.CloseUIViewCom<SpineMainView>();
    }

    #endregion

}