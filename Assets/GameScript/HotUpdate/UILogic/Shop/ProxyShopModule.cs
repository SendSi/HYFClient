using System;

public class ProxyShopModule : BaseInstance<ProxyShopModule>, IProxy
{
    private const string pkgName = "Shop";

    public void CheckLoad(Action finishCB)
    {
        FGUILoader.GetInstance().AddPackage(pkgName, finishCB);
    }
}
