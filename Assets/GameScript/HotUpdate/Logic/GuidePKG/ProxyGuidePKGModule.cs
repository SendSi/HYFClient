using System;

public class ProxyGuidePKGModule : Singleton<ProxyGuidePKGModule>,IProxy
{
    private const string pkgName = "GuidePKG";
    public void CheckLoad(Action finishCB)
    {
        FGUILoader.Instance.AddPackage(pkgName,finishCB);
    }
    
    
}
