public static class AppConfig
{
    public static string hostServerIP = "http://192.168.15.20"; //cdn资源服务器
    // public static string hostServerIP = "http://127.0.0.1"; //cdn资源服务器

    public static string appVersion = "v1.0"; //打exe时(apk时) 的版本

    public static int designResolutionX = 1334; //ui设计尺寸 宽
    public static int designResolutionY = 750; //ui设计尺寸 高

    public static string currLang = "SimChinese"; //当前出APK时的语言 简体中文SimChinese  繁体中文TraChinese  英文English          //初次启动  改变后再次启动

    public static float bgmVolume = 0.66f; //bgm的默认声音大小  
    public static float musicVolume = 0.66f; //音效的默认声音大小  

    #region editor下使用的

    public static string resVersion = "v1.0"; //yooAsset生成资源时 的版本  复制时有用  editor下使用
    public static string localCDN = "D:/WWW_hyfclient/CDN/"; //本地cdn资源服务器 磁盘路径

    #endregion
}