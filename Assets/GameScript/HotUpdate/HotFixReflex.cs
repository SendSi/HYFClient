using UnityEngine;
public class HotFixReflex
{
    //反射调用
    public static void Run()
    {
        Debug.LogWarning("HotFixReflex-->Run");
        ProxyLoginModule.Instance.OpenLoginMainView();
        
        ManagerBinder.BindAll();
    }
    public static void Destroy()
    {
        Debug.LogWarning("HotFixReflex-->Destroy");
        ManagerBinder.UnBind();
    }
}