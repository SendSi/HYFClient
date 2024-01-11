using UnityEngine;

//反射调用
public class HotFixReflex
{
    //反射调用
    public static void Run()
    {
        Debug.LogWarning("HotFixReflex-->Run");
        //var gameMain = GameObject.Find("GameMain");//Find元素
        LanguageUtils.Instance.Begin();//时序有要求
        
        ProxyLoginModule.Instance.OpenLoginMainView();//时序有要求
        ProtocalBinder.BindAll();
        ManagerBinder.BindAll();
        
        // if (gameMain != null) { gameMain.AddComponent<SafeAreaUtils>(); }
    }

    public static void Destroy()
    {
        Debug.LogWarning("HotFixReflex-->Destroy");
        ProtocalBinder.UnBind();
        ManagerBinder.UnBind();
    }
}