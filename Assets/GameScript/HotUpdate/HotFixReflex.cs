using UnityEngine;

//反射调用
public class HotFixReflex
{
    //反射调用
    public static void Run()
    {
        Debug.LogWarning("HotFixReflex-->Run");
        
        ProxyLoginModule.Instance.OpenLoginMainView();
        ProtocalBinder.BindAll();
    }

    public static void Destroy()
    {
        Debug.LogWarning("HotFixReflex-->Destroy");
        ProtocalBinder.UnBind();
    }
}