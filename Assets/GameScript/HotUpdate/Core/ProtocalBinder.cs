public class ProtocalBinder
{
    public static void BindAll()
    {
        var channel = GrpcChannelManager.Instance.InitMainChannel(AppConfig.serverURL);
        ProtocalLogin.Instance.ListenLogin(channel);
        ProtocalShop.Instance.ListenShop(channel);
        ProtocalRole.Instance.ListenRole(channel);
        ProtocalBag.Instance.ListenBag(channel);
    }

    public static void UnBind()
    {
        GrpcChannelManager.Instance.Dispose();
        ProtocalLogin.Instance.Dispose();
        ProtocalShop.Instance.Dispose();
        ProtocalRole.Instance.Dispose();
        ProtocalBag.Instance.Dispose();
    }
}