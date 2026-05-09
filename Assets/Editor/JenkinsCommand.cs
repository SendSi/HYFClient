#if UNITY_EDITOR
using UnityEditor;
using YooAsset.Editor;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEditor.SceneManagement;

/// <summary> Jenkins 打包命令</summary>
public static class JenkinsCommand
{
    private static string _buildTarget = "Android";

    [MenuItem("Jenkins/自行核对AppConfig.cs1",false,101)]
    public static void JenkinsDesc1()
    {
        Debug.LogError("自行核对 AppConfig.cs 字段 appVersion resVersion playModeStr");
    }

    [MenuItem("Jenkins/当前平台_出_整包",false,102)]
    public static void JenkinsBuildTarget()
    {
        _buildTarget = GetCurrentBuildTargetString();
        BuildGame();
    }

    
    [MenuItem("Jenkins/自行核对AppConfig.cs2",false,1001)]
    public static void JenkinsDesc2()
    {
        Debug.LogError("自行核对 AppConfig.cs 字段  resVersion");
    }

    [MenuItem("Jenkins/当前平台_出_热更",false,1002)]
    public static void JenkinsBuildHotPKG()
    {
        _buildTarget = GetCurrentBuildTargetString();
        BuildHotPKG();
    }


    /*  两路径要配对哦
 @echo off
 set UNITY=C:\Program Files (x86)\UnityHub3.6\install\2022.3.15f1\Editor\Unity.exe
 set PROJ=D:\git_Project\HYFClient

@echo off
:: 先杀掉所有 Unity 进程，避免冲突
taskkill /im Unity.exe /f

 :: 下面这4个都是 Jenkins 传来的参数
 set BUILD_TARGET=%BUILD_TARGET%
 set PLAY_MODE=%PLAY_MODE%
 set APP_VERSION=%APP_VERSION%
 set RES_VERSION=%RES_VERSION%

 :: 【关键】把所有参数传给 Unity
 "%UNITY%"^
  -batchmode^
  -nographics^
  -projectPath "%PROJ%"^
  -executeMethod JenkinsCommand.BuildGame^
  -BUILD_TARGET=%BUILD_TARGET%^
  -PLAY_MODE=%PLAY_MODE%^
  -APP_VERSION=%APP_VERSION%^
  -RES_VERSION=%RES_VERSION%^
  -quit
     */
    /// <summary>给Jenkins调用的 整包</summary>
    public static void BuildGame()
    {
        try
        {
            string[] args = Environment.GetCommandLineArgs(); //jenkins使用的 
            string buildTarget = GetJenkinsArg(args, "-BUILD_TARGET=", _buildTarget);
            string playModeStr = GetJenkinsArg(args, "-PLAY_MODE=", AppConfig.playModeStr); //HostPlayMode  或  OfflinePlayMode
            string appVersion = GetJenkinsArg(args, "-APP_VERSION=", AppConfig.appVersion);
            string resVersion = GetJenkinsArg(args, "-RES_VERSION=", AppConfig.resVersion);
            Debug.Log($"=== Build Parameters === | BuildTarget: {buildTarget} | PlayMode: {playModeStr} | AppVersion: {appVersion} | ResVersion: {resVersion}");

            ModifyAppConfig2Version(appVersion, resVersion); //修改appConfig脚本
            SetPlayMode(playModeStr); //设置热更状态
            SwitchBuildTarget(buildTarget); //切换平台
            DeleteStreamingAssetsYooFolder(); //
            AssetDatabase.Refresh();

            HybridCLR_GenerateAll();
            HybridCLR_CopyToHotfix();
            HybridCLR_ObfuzGenAll_2_Copy();
            YooBuildDefaultPackage(resVersion, buildTarget);
            YooBuildHotFixPackage(resVersion, buildTarget);
            AssetResCopyToCDN(appVersion, resVersion, playModeStr);
            AssetDatabase.Refresh();
            BuildToGameFile(appVersion, buildTarget, playModeStr);
        }
        catch (Exception e)
        {
            Debug.LogError("Build Failed: " + e.Message);
            EditorApplication.Exit(1);
        }
    }


    /*
 @echo off
 set UNITY=C:\Program Files (x86)\UnityHub3.6\install\2022.3.15f1\Editor\Unity.exe
 set PROJ=D:\git_Project\HYFClient

@echo off
:: 先杀掉所有 Unity 进程，避免冲突
taskkill /im Unity.exe /f

 :: 下面这2个都是 Jenkins 传来的参数
 set BUILD_TARGET=%BUILD_TARGET%
 set RES_VERSION=%RES_VERSION%

 :: 【关键】把所有参数传给 Unity
 "%UNITY%"^
  -batchmode^
  -nographics^
  -projectPath "%PROJ%"^
  -executeMethod JenkinsCommand.BuildHotPKG^
  -BUILD_TARGET=%BUILD_TARGET%^
  -RES_VERSION=%RES_VERSION%^
  -quit
     */
    /// <summary>给Jenkins调用的 热更</summary>
    public static void BuildHotPKG()
    {
        string[] args = Environment.GetCommandLineArgs();
        string buildTarget = GetJenkinsArg(args, "-BUILD_TARGET=", _buildTarget);
        string resVersion = GetJenkinsArg(args, "-RES_VERSION=", AppConfig.resVersion);
        Debug.Log($"=== Build Parameters === | BuildTarget: {buildTarget} |  ResVersion: {resVersion}");

        SwitchBuildTarget(buildTarget); //切换平台
        ModifyAppConfigResVersions(resVersion); //修改appConfig脚本
        AssetDatabase.Refresh();
        HybridCLR_ActiveBuildTarget(); //打代码
        HybridCLR_CopyToHotfix(); //copy代码
        HybridCLR_ObfuzGenAll_2_Copy();
        YooBuildDefaultPackage(resVersion, buildTarget, true);
        YooBuildHotFixPackage(resVersion, buildTarget, true);
        AssetDatabase.Refresh();
        AssetResCopyToCDN(AppConfig.appVersion, resVersion, "HostPlayMode");
    }

    private static void ModifyAppConfigResVersions(string newResVersion)
    {
        string appConfigPath = @"Assets/GameScript/AOT/AppConfig.cs";
        string fullPath = Path.Combine(Application.dataPath, "../", appConfigPath);
        fullPath = Path.GetFullPath(fullPath);
        if (!File.Exists(fullPath))
        {
            Debug.LogError($"AppConfig.cs 不存在：{fullPath}，跳过修改");
            return;
        }

        string content = File.ReadAllText(fullPath);

        content = Regex.Replace(
            content,
            @"public\s+static\s+string\s+resVersion\s*=\s*""[^""]*""\s*;",
            $"public static string resVersion = \"{newResVersion}\";",
            RegexOptions.Multiline
        );

        File.WriteAllText(fullPath, content);
        AssetDatabase.Refresh();
    }


    static void HybridCLR_ActiveBuildTarget()
    {
        HybridCLR.Editor.Commands.CompileDllCommand.CompileDll(EditorUserBuildSettings.activeBuildTarget, EditorUserBuildSettings.development);
    }


    /// <summary>
    /// 切换平台：Android / Windows
    /// 已经是目标平台则不重复切换
    /// </summary>
    static void SwitchBuildTarget(string targetStr)
    {
        BuildTarget target;
        BuildTargetGroup targetGroup;

        if (targetStr == "Android")
        {
            target = BuildTarget.Android;
            targetGroup = BuildTargetGroup.Android;
        }
        else
        {
            target = BuildTarget.StandaloneWindows64;
            targetGroup = BuildTargetGroup.Standalone;
        }

        // 如果已经是当前平台，跳过切换
        if (EditorUserBuildSettings.activeBuildTarget == target)
        {
            Debug.Log($"Already on target platform: {target}, no need to switch");
            return;
        }

        Debug.Log($"Switching platform to: {target} ...");

        // 同步切换平台（批处理模式下稳定）
        EditorUserBuildSettings.SwitchActiveBuildTarget(targetGroup, target);

        // 等待导入完成
        AssetDatabase.Refresh();
        Debug.Log($"Platform switch completed: {target}");
    }

    /// <summary> 尝试打开场景 → 设置 PlayMode </summary>
    static void SetPlayMode(string playModeStr)
    {
        YooAsset.EPlayMode playMode = YooAsset.EPlayMode.OfflinePlayMode;
        if (!string.IsNullOrEmpty(playModeStr))
        {
            Enum.TryParse(playModeStr, out playMode);
        }

        EditorSceneManager.OpenScene("Assets/GameRes/Scene/Init.unity");

        var gameMain = GameObject.Find("GameMain")?.GetComponent<GameMain>();
        if (gameMain != null)
        {
            gameMain.PlayMode = playMode;
            EditorUtility.SetDirty(gameMain);
            Debug.Log($"PlayMode has been set to: {playMode}");
        }

        EditorSceneManager.SaveOpenScenes();
        AssetDatabase.Refresh();
    }

    /// <summary>  Jenkins传入过来的  Cmd工具方法：读取命令行参数 </summary>
    /// <param name="defaultValue">默认值</param>
    private static string GetJenkinsArg(string[] args, string key, string defaultValue = "")
    {
        if (args == null || args.Length == 0)
        {
            return defaultValue; // 检查args是否为null或空数组
        }

        var arg = args.FirstOrDefault(x => x.StartsWith(key));
        string result = arg?.Replace(key, "") ?? defaultValue;
        return result;
    }


    /// <summary>
    /// 直接修改 AppConfig.cs 文本，替换 appVersion 和 resVersion 的值
    /// </summary>
    /// <param name="newAppVersion">要替换成的 appVersion 值，如 "v1.2.3"</param>
    /// <param name="newResVersion">要替换成的 resVersion 值，如 "v1.2.3"</param>
    static void ModifyAppConfig2Version(string newAppVersion, string newResVersion)
    {
        string appConfigPath = @"Assets/GameScript/AOT/AppConfig.cs";
        string fullPath = Path.Combine(Application.dataPath, "../", appConfigPath);
        fullPath = Path.GetFullPath(fullPath);
        if (!File.Exists(fullPath))
        {
            Debug.LogError($"AppConfig.cs not found: {fullPath}, skip update");
            return;
        }

        string content = File.ReadAllText(fullPath);
        content = Regex.Replace(
            content,
            @"public\s+static\s+string\s+appVersion\s*=\s*""[^""]*""\s*;",
            $"public static string appVersion = \"{newAppVersion}\";",
            RegexOptions.Multiline
        );

        content = Regex.Replace(
            content,
            @"public\s+static\s+string\s+resVersion\s*=\s*""[^""]*""\s*;",
            $"public static string resVersion = \"{newResVersion}\";",
            RegexOptions.Multiline
        );

        File.WriteAllText(fullPath, content);
        AssetDatabase.Refresh();
        Debug.Log($"Updated AppConfig.cs: appVersion={newAppVersion}, resVersion={newResVersion}");
    }

    static void DeleteStreamingAssetsYooFolder()
    {
        string yooFolderPath = Path.Combine(Application.streamingAssetsPath, "yoo");
        if (Directory.Exists(yooFolderPath))
        {
            try
            {
                Directory.Delete(yooFolderPath, recursive: true);
            }
            catch (System.Exception e)
            {
                Debug.LogError($"删除 yoo 文件夹失败：{e.Message}");
            }
        }
        else
        {
            Debug.Log("未找到 yoo 文件夹，无需删除");
        }
    }

    // HybridCLR 生成全部
    static void HybridCLR_GenerateAll()
    {
        bool ok = EditorApplication.ExecuteMenuItem("HybridCLR/Generate/All");
        if (!ok) throw new Exception("Step1 Failed-->HybridCLR/Generate/All");
    }

    // HybridCLR CopyToHotfix
    static void HybridCLR_CopyToHotfix()
    {
        bool ok = EditorApplication.ExecuteMenuItem(CLRHelperEditor.menuDLLCopy); //"HybridCLR/Generate/All_CopyTo_GameResHotFix");
        if (!ok) throw new Exception($"Step2 Failed-->{CLRHelperEditor.menuDLLCopy}");
    }

    // 构建 DefaultPackage（适配你版本）
    static void YooBuildDefaultPackage(string version, string buildTarget, bool isHot = false)
    {
        BuiltinBuildParameters p = new BuiltinBuildParameters();
        p.PackageName = "DefaultPackage";
        p.PackageVersion = version;
        p.BuildOutputRoot = AssetBundleBuilderHelper.GetDefaultBuildOutputRoot();
        p.BuildinFileRoot = AssetBundleBuilderHelper.GetStreamingAssetsRoot();

        if (buildTarget.Contains("Android"))
        {
            p.BuildTarget = BuildTarget.Android;
        }
        else
        {
            p.BuildTarget = BuildTarget.StandaloneWindows64;
        }

        p.BuildPipeline = "BuiltinBuildPipeline";
        p.BuildMode = EBuildMode.ForceRebuild;
        if (isHot == false) //全包
        {
            p.BuildinFileCopyOption = EBuildinFileCopyOption.ClearAndCopyAll;
        }
        else //热更包
        {
            p.BuildinFileCopyOption = EBuildinFileCopyOption.None;
        }

        p.CompressOption = ECompressOption.LZ4;
        p.FileNameStyle = EFileNameStyle.HashName;
        p.VerifyBuildingResult = true;
        p.EncryptionServices = null;

        BuiltinBuildPipeline pipeline = new BuiltinBuildPipeline();
        BuildResult result = pipeline.Run(p, true);

        if (result == null || result.Success == false)
            throw new Exception(" DefaultPackage build failed");
    }

    // 4. 构建 HotFixPackage（适配你版本）
    static void YooBuildHotFixPackage(string resVersion, string buildTarget, bool isHot = false)
    {
        RawFileBuildParameters p = new RawFileBuildParameters();
        p.PackageName = "HotFixPackage";
        p.PackageVersion = resVersion;
        p.BuildOutputRoot = AssetBundleBuilderHelper.GetDefaultBuildOutputRoot();
        p.BuildinFileRoot = AssetBundleBuilderHelper.GetStreamingAssetsRoot();
        if (buildTarget.Contains("Android"))
        {
            EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
            p.BuildTarget = BuildTarget.Android;
        }
        else
        {
            EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, BuildTarget.StandaloneWindows64);
            p.BuildTarget = BuildTarget.StandaloneWindows64;
        }

        p.BuildPipeline = "RawFileBuildPipeline";
        p.BuildMode = EBuildMode.ForceRebuild;
        if (isHot == false) //全包
        {
            p.BuildinFileCopyOption = EBuildinFileCopyOption.ClearAndCopyAll;
        }
        else //热更
        {
            p.BuildinFileCopyOption = EBuildinFileCopyOption.None;
        }

        p.EncryptionServices = null;
        p.FileNameStyle = EFileNameStyle.HashName;
        p.VerifyBuildingResult = true;
        RawFileBuildPipeline pipeline = new RawFileBuildPipeline();
        BuildResult result = pipeline.Run(p, enableLog: true);
        if (result == null || result.Success == false)
        {
            throw new Exception("HotFixPackage build failed: " + result.ErrorInfo);
        }
    }

    // 生成出的yooAsset资源 复制资源到CDN
    static void AssetResCopyToCDN(string appVersion, string resVersion, string playModeStr)
    {
        if (playModeStr.Equals("HostPlayMode"))
        {
            YooHelperEditor.RunCopyResTarget(appVersion, resVersion); //热更状态下 的 才需去copy到cdn
        }
    }

    //  打包 APK或exe
    static void BuildToGameFile(string appVersion, string buildTarget, string playModeStr)
    {
        string version = appVersion.Replace("v", "");
        PlayerSettings.bundleVersion = version;
        PlayerSettings.applicationIdentifier = $"com.HYFClient.ML";
        string[] scenes = EditorBuildSettings.scenes
            .Where(scene => scene.enabled)
            .Select(scene => scene.path)
            .ToArray();

        BuildPlayerOptions options = new BuildPlayerOptions();
        options.scenes = scenes;
        options.options = BuildOptions.None;

        // 根据平台自动选择打包 apk 或 exe
        if (buildTarget == "Android")
        {
            options.target = BuildTarget.Android;
            options.locationPathName = $"BuildAndroid/hyf_{playModeStr}_{version}.apk";
            Debug.Log($"Starting build for Android: {options.locationPathName}");
        }
        else
        {
            options.target = BuildTarget.StandaloneWindows64;
            options.locationPathName = $"BuildWindows/hyf_{playModeStr}_{version}.exe";
            Debug.Log($"Starting build for Windows: {options.locationPathName}");
        }

        BuildPipeline.BuildPlayer(options);
        Debug.Log($"=== Jenkins Build Completed, Output Path: {options.locationPathName} ===");
    }


    /// <summary> 获取当前构建平台的字符串表示 </summary>
    private static string GetCurrentBuildTargetString()
    {
        BuildTarget activeTarget = EditorUserBuildSettings.activeBuildTarget;
        switch (activeTarget)
        {
            case BuildTarget.Android:
                return "Android";
            case BuildTarget.StandaloneWindows:
            case BuildTarget.StandaloneWindows64:
                return "Windows";
            default:
                Debug.LogWarning($"[GetCurrentBuildTargetString] 未识别的平台: {activeTarget}，默认返回Android");
                return "Android";
        }
    }

    /// <summary> 加密 </summary>
    private static void HybridCLR_ObfuzGenAll_2_Copy()
    {
        bool ok = EditorApplication.ExecuteMenuItem("HybridCLR/ObfuzExtension/GenerateAll");
        if (!ok) throw new Exception("生成Obfuz Failed-->HybridCLR/ObfuzExtension/GenerateAll");
        
        ok = EditorApplication.ExecuteMenuItem("HybridCLR/ObfuzExtension/GenerateAll_CopyTo_GameResHotFix");
        if (!ok) throw new Exception("复制Obfuz Failed-->HybridCLR/ObfuzExtension/GenerateAll_CopyTo_GameResHotFix");
    }
}

#endif