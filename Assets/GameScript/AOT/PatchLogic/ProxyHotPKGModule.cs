using FairyGUI;
using HotPKG;
public class ProxyHotPKGModule : Singleton<ProxyHotPKGModule>
{
    private const string pkgName = "HotPKG";
    private HFView mView; //只有一个页面
    public void OpenHFView()
    {
        UIPackage.AddPackage("HotPKG");
        HotPKGBinder.BindAll(); //绑定脚本
        var gCom = UIPackage.CreateObject(pkgName, "HFView").asCom;
        gCom.MakeFullScreen();
        GRoot.inst.AddChild(gCom);
        gCom.AddRelation(GRoot.inst, RelationType.Size);
        gCom.fairyBatching = true;
        gCom.OnInit(); //继承方法 onClick itemRenderer *** 在此声明呗
        mView = gCom as HFView;
        mView.SetData("打开页面数据传递");
    }

    public void CloseHFView()
    {
        if (mView != null)
        {
            mView.Dispose();
            UIPackage.RemovePackage(pkgName);
        }
    }
}