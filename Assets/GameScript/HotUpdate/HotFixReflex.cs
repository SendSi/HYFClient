using UnityEngine;
public class HotFixReflex
{
    //反射调用
    public static void Run()
    {
        Debug.LogWarning("HotFixReflex-->Run");
        var gameMain = GameObject.Find("GameMain");//Find元素

        ProxyLoginModule.Instance.OpenLoginMainView();
        
        ManagerBinder.BindAll();
        
        if (gameMain != null) { gameMain.AddComponent<SafeAreaUtils>(); }
    }
    public static void Destroy()
    {
        Debug.LogWarning("HotFixReflex-->Destroy");
        ManagerBinder.UnBind();
    }
}