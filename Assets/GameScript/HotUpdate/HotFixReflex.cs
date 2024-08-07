//反射调用
public class HotFixReflex
{
    //反射调用
    public static void Run()
    {
        Debuger.LogWarning("HotFixReflex-->Run");
        //var gameMain = GameObject.Find("GameMain");//Find元素
        // if (gameMain != null) { gameMain.AddComponent<SafeAreaUtils>(); }
        
        LanguageUtils.Instance.Begin();//时序有要求
        
        ProxyLoginModule.Instance.OpenLoginMainView();//时序有要求
        ProtocalBinder.BindAll();
        ManagerBinder.BindAll();

        CfgLubanMgr.Instance.Begin();//导表初始化
        AudioMgr.Instance.Begin();
        GMManager.Instance.Begin();
    }

    public static void Destroy()
    {
        Debuger.LogWarning("HotFixReflex-->Destroy");
        ProtocalBinder.UnBind();
        ManagerBinder.UnBind();
        
        AudioMgr.Instance.Dispose();
    }
}