using UnityEngine;

//反射调用
public class HotFixReflex
{
    //反射调用
    public static void Run()
    {
        Debug.LogWarning("HotFixReflex-->Run");
        //var gameMain = GameObject.Find("GameMain");//Find元素
        // if (gameMain != null) { gameMain.AddComponent<SafeAreaUtils>(); }
        
        LanguageUtils.Instance.Begin();//时序有要求
        
        ProxyLoginModule.Instance.OpenLoginMainView();//时序有要求
        ProtocalBinder.BindAll();
        ManagerBinder.BindAll();

        AudioMgr.Instance.Begin();
        GMManager.Instance.Begin();
    }

    public static void Destroy()
    {
        Debug.LogWarning("HotFixReflex-->Destroy");
        ProtocalBinder.UnBind();
        ManagerBinder.UnBind();
        
        AudioMgr.Instance.Dispose();
    }
}