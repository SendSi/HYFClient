using UnityEngine;

public class ManagerBinder
{
    public static void BindAll()
    {
        BagManager.Instance.Begin();
    }

    public static void UnBind()
    {
        BagManager.Instance.Dispose();
    }
}