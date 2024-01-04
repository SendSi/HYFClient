//反射调用
public class HotFixReflex
{
    //反射调用
    public static void Run()
    {
        ProxyLoginModule.Instance.OpenLoginMainView();

        ServicePushInfo.Instance.Run();
    }
}