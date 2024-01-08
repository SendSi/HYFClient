using System;

public class ProxyShopModule : Singleton<ProxyShopModule>, IProxy
{
    private const string pkgName = "Shop";

    public void CheckLoad(Action finishCB)
    {
        FGUILoader.Instance.AddPackage(pkgName, finishCB);
    }
}
