using UnityEditor;
using YooAsset.Editor;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using YooAsset;
using UnityEditor.SceneManagement;


/// <summary> 打整包 </summary>
public static class JenkinsCommand
{
    public static void BuildGame()
    {
        try
        {
            string[] args = Environment.GetCommandLineArgs();

            string buildTarget = GetArg(args, "-BUILD_TARGET=");
            string playModeStr = GetArg(args, "-PLAY_MODE=");
            string appVersion = GetArg(args, "-APP_VERSION=");
            string resVersion = GetArg(args, "-RES_VERSION=");

            Debug.Log($"=== 打包参数 ===");
            Debug.Log($"目标平台----buildTarget: {buildTarget}");
            Debug.Log($"运行模式----playModeStr: {playModeStr}");
            Debug.Log($"App版本----appVersion: {appVersion}");
            Debug.Log($"资源版本----resVersion: {resVersion}");


            // 2. 解析 PlayMode（你项目里的枚举）
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
                Debug.Log($"已设置 PlayMode = {playMode}");
            }
            EditorSceneManager.SaveOpenScenes(); // 保存修改后的场景
            AssetDatabase.Refresh();

            // 打包逻辑
            BuildPlayerOptions opt = new BuildPlayerOptions();
            opt.scenes = new[] { "Assets/GameRes/Scene/Init.unity" };
            if (buildTarget == "Android")
            {
                opt.target = BuildTarget.Android;
                opt.locationPathName = $"Build/Game_{appVersion}_{playMode}.apk";
            }
            else
            {
                opt.target = BuildTarget.StandaloneWindows64;
                opt.locationPathName = $"Build/Game_{appVersion}_{playMode}.exe";
            }

            BuildPipeline.BuildPlayer(opt);

            // // 3. 执行打包（Android为例）
            // BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
            // buildPlayerOptions.scenes = new[] { "Assets/Init.unity" };
            // buildPlayerOptions.locationPathName = "Build/MyGame.apk";
            // buildPlayerOptions.target = BuildTarget.Android;
            // buildPlayerOptions.options = BuildOptions.None;

            // BuildPipeline.BuildPlayer(buildPlayerOptions);
            // Debug.Log("打包完成！");


            // string appVersion = Environment.GetEnvironmentVariable("PLAY_MODE") ?? "v1.0.0";
            // string resVersion = Environment.GetEnvironmentVariable("RES_VERSION") ?? "v1.0.0";

            // UpdateAppConfigVersions(appVersion, resVersion); //修改appConfig脚本

            // Debug.Log($"=== Jenkins 开始 === Yoo版本:{resVersion}");
            // Step1_HybridCLR_GenerateAll();
            // Step2_HybridCLR_CopyToHotfix();
            // Step3_Build_DefaultPackage(resVersion);
            // Step4_Build_HotFixPackage(resVersion);
            // Step5_Copy_To_CNDTarget(appVersion, resVersion);
            // Step6_BuildAPK(appVersion);
            // Debug.Log("===Jenkins 全部完成 ===");
        }
        catch (Exception e)
        {
            Debug.LogError("失败：" + e.Message);
            EditorApplication.Exit(1);
        }
    }

    // 工具方法：读取命令行参数
    private static string GetArg(string[] args, string key)
    {
        var arg = args.FirstOrDefault(x => x.StartsWith(key));
        return arg?.Replace(key, "") ?? "";
    }


    /// <summary>
    /// 直接修改 AppConfig.cs 文本，替换 appVersion 和 resVersion 的值
    /// </summary>
    /// <param name="newAppVersion">要替换成的 appVersion 值，如 "v1.2.3"</param>
    /// <param name="newResVersion">要替换成的 resVersion 值，如 "v1.2.3"</param>
    private static void UpdateAppConfigVersions(string newAppVersion, string newResVersion)
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
        Debug.Log($"✅ 已更新 AppConfig.cs：appVersion={newAppVersion}, resVersion={newResVersion}");
    }

    // 1. HybridCLR Generate All
    static void Step1_HybridCLR_GenerateAll()
    {
        bool ok = EditorApplication.ExecuteMenuItem("HybridCLR/Generate/All");
        if (!ok) throw new Exception("Step1 步骤1失败-->HybridCLR/Generate/All");
    }

    // 2. HybridCLR CopyToHotfix
    static void Step2_HybridCLR_CopyToHotfix()
    {
        bool ok = EditorApplication.ExecuteMenuItem(CLRHelperEditor
            .menuDLLCopy); //"HybridCLR/Generate/All_CopyTo_GameResHotFix");
        if (!ok) throw new Exception($"Step2 步骤2失败-->{CLRHelperEditor.menuDLLCopy}");
    }

    // 3. 构建 DefaultPackage（适配你版本）
    static void Step3_Build_DefaultPackage(string version)
    {
        BuiltinBuildParameters p = new BuiltinBuildParameters();
        p.PackageName = "DefaultPackage";
        p.PackageVersion = version;
        p.BuildOutputRoot = AssetBundleBuilderHelper.GetDefaultBuildOutputRoot();
        p.BuildinFileRoot = AssetBundleBuilderHelper.GetStreamingAssetsRoot();
        p.BuildTarget = BuildTarget.Android;
        p.BuildMode = EBuildMode.ForceRebuild;
        p.CompressOption = ECompressOption.LZ4;
        p.FileNameStyle = EFileNameStyle.HashName;
        p.VerifyBuildingResult = true;
        p.BuildinFileCopyOption = EBuildinFileCopyOption.ClearAndCopyAll;
        p.EncryptionServices = null;

        BuiltinBuildPipeline pipeline = new BuiltinBuildPipeline();
        BuildResult result = pipeline.Run(p, true);

        if (result == null || result.Success == false)
            throw new Exception("Step3 DefaultPackage 打包失败");
    }

    // 4. 构建 HotFixPackage（适配你版本）
    static void Step4_Build_HotFixPackage(string version)
    {
        RawFileBuildParameters p = new RawFileBuildParameters();
        p.PackageName = "HotFixPackage";
        p.PackageVersion = version;
        p.BuildOutputRoot = AssetBundleBuilderHelper.GetDefaultBuildOutputRoot();
        p.BuildinFileRoot = AssetBundleBuilderHelper.GetStreamingAssetsRoot();
        p.BuildTarget = BuildTarget.Android;
        p.BuildMode = EBuildMode.ForceRebuild;
        p.FileNameStyle = EFileNameStyle.HashName;
        p.VerifyBuildingResult = true;
        p.BuildinFileCopyOption = EBuildinFileCopyOption.ClearAndCopyAll;
        p.EncryptionServices = null;

        RawFileBuildPipeline pipeline = new RawFileBuildPipeline();
        BuildResult result = pipeline.Run(p, true); // 这里用 Run，不是 Build！

        if (result == null || result.Success == false)
            throw new Exception("Step4 HotFixPackage 打包失败");
    }

    // 
    static void Step5_Copy_To_CNDTarget(string appVersion, string resVersion)
    {
        YooHelperEditor.RunCopyResTarget(appVersion, resVersion);
    }

    // 6. 打包 APK
    static void Step6_BuildAPK(string appVersion)
    {
        string version = appVersion.Replace("v", "");
        PlayerSettings.bundleVersion = version;
        PlayerSettings.applicationIdentifier = $"com.HYFClient.ML";
        string[] scenes = EditorBuildSettings.scenes
            .Where(scene => scene.enabled)
            .Select(scene => scene.path)
            .ToArray();

        string outputPath = $"BuildAPK/hyf_{version}.apk";

        BuildPlayerOptions options = new BuildPlayerOptions
        {
            scenes = scenes,
            locationPathName = outputPath,
            target = BuildTarget.Android,
            options = BuildOptions.None
        };

        BuildPipeline.BuildPlayer(options);
        Debug.Log($"=== Jenkins 打包完成，输出路径：{outputPath} ===");
    }



}