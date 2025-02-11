//虽是枚举  还是用驼峰吧  不用纯大写  读起来方便

public enum EventEnumAOT
{
    EE_UserTryInitialize=1001,//用户尝试再次初始化资源包
    EE_UserBeginDownloadWebFiles=1002,//用户开始下载网络文件
    EE_UserTryUpdatePackageVersion=1003,//用户尝试再次更新静态版本
    EE_UserTryUpdatePatchManifest=1004,//用户尝试再次更新补丁清单
    EE_UserTryDownloadWebFiles=1005,//用户尝试再次下载网络文件
    
    EE_InitializeFailed=1006,//补丁包初始化失败
    EE_PatchStatesChange=1007,//补丁流程步骤改变
    EE_FoundUpdateFiles=1008,//发现更新文件
    EE_DownloadProgressUpdate=1009,//下载进度更新
    EE_PackageVersionUpdateFailed=1010,//资源版本号更新失败
    EE_PatchManifestUpdateFailed=1011,//补丁清单更新失败
    EE_WebFileDownloadFailed=1012,//网络文件下载失败
    
    EE_NumOfCircleToShow=1013,//划上几圈 就出现log视图  事件
}
