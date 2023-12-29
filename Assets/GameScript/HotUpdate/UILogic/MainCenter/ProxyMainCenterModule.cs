using MainCenter;
using System;
using UnityEngine;

public class ProxyMainCenterModule : BaseInstance<ProxyMainCenterModule>, IProxy
{
    private const string pkgName = "MainCenter";

    public void CheckLoad(Action finishCB)
    {
        FGUILoader.GetInstance().AddPackage(pkgName, finishCB);
    }

    public void OpenMainCenterView()
    {
        CheckLoad(() =>
        {
            var view = UIMgr.GetInstance().OpenUIViewCom<MainCenterView>(pkgName);
            if (view != null)
            {
                view.SetData();
            }
            else
            {
                Debug.LogError("为何为null--没走MainCenterBinder.BindAll()  此业务包被当成依赖包了");
            }
        });
    }

    public void CloseMainCenterView()
    {
        UIMgr.GetInstance().CloseUIViewCom<MainCenterView>();
    }
}
