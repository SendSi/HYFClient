using FairyGUI;

public static class WindowExpand
{
    /// <summary>
    /// 扩展方法   window继承closeEventHandler方法,然后调用此方法
    /// 调用此方法 会检测移除无引用的业务包
    /// </summary>
    public static void CloseWindowExpand(this Window win)
    {
        UIMgr.Instance.CloseWindowExpand(win);
    }

}
