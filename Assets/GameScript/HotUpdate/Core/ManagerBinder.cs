using UnityEngine;

public class ManagerBinder
{
    public static void BindAll()
    {
        LoginManager.Instance.ListenLogin();
        BagManager.Instance.ListenBag();
        RoleManager.Instance.ListenRole();
        ShopManager.Instance.ListenShop();

        GMManager.Instance.ListenGM();
    }

    public static void UnBind()
    {
        LoginManager.Instance.Dispose();
        BagManager.Instance.Dispose();
        RoleManager.Instance.Dispose();
        ShopManager.Instance.Dispose();
    }
}