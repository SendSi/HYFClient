using UnityEditor;
using YooAsset.Editor;
using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

/// <summary> 已有整包的后的 热更包---只出资源 </summary>
public static class JenkinsBuild_HotVer
{
    public static void BuildHotPackage()
    {
        try
        {
            string resVersion = Environment.GetEnvironmentVariable("RES_VERSION") ?? "v1.0.0";
            UpdateAppConfigVersions(resVersion); //修改appConfig脚本

            Debug.Log($"=== Jenkins 开始 === Yoo版本:{resVersion}");
            Step1_HybridCLR_ActiveBuildTarget();
            Step2_HybridCLR_CopyToHotfix();
            Step3_Build_DefaultPackage(resVersion);
            Step4_Build_HotFixPackage(resVersion);
            Step5_Copy_To_CNDTarget(resVersion);
            Debug.Log("===Jenkins hotUpdate 全部完成 ===");
        }
        catch (Exception e)
        {
            Debug.LogError("失败：" + e.Message);
            EditorApplication.Exit(1);
        }
    }


    /// <summary>
    /// 直接修改 AppConfig.cs 文本，替换 appVersion 和 resVersion 的值
    /// </summary>
    /// <param name="newAppVersion">要替换成的 appVersion 值，如 "v1.2.3"</param>
    /// <param name="newResVersion">要替换成的 resVersion 值，如 "v1.2.3"</param>
    private static void UpdateAppConfigVersions(string newResVersion)
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
        Debug.Log($"✅ 已更新 AppConfig.cs： resVersion={newResVersion}");
    }

    // 1. ActiveBuildTarget
    static void Step1_HybridCLR_ActiveBuildTarget()
    {
        HybridCLR.Editor.Commands.CompileDllCommand.CompileDll(EditorUserBuildSettings.activeBuildTarget, EditorUserBuildSettings.development);
    }

    // 2. HybridCLR CopyToHotfix
    static void Step2_HybridCLR_CopyToHotfix()
    {
        bool ok = EditorApplication.ExecuteMenuItem(CLRHelperEditor.menuDLLCopy);
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
        p.BuildMode = EBuildMode.IncrementalBuild;
        p.CompressOption = ECompressOption.LZ4;
        p.FileNameStyle = EFileNameStyle.HashName;
        p.VerifyBuildingResult = true;
        p.BuildinFileCopyOption = EBuildinFileCopyOption.None;
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
        p.BuildMode = EBuildMode.SimulateBuild;
        p.FileNameStyle = EFileNameStyle.HashName;
        p.VerifyBuildingResult = true;
        p.BuildinFileCopyOption = EBuildinFileCopyOption.None;
        p.EncryptionServices = null;

        RawFileBuildPipeline pipeline = new RawFileBuildPipeline();
        BuildResult result = pipeline.Run(p, true); // 这里用 Run，不是 Build！

        if (result == null || result.Success == false)
            throw new Exception("Step4 HotFixPackage 打包失败");
    }

    // 
    static void Step5_Copy_To_CNDTarget(string resVersion)
    {
        var appVersion = AppConfig.appVersion;
        YooHelperEditor.RunCopyResTarget(appVersion, resVersion);
    }

    [MenuItem("HybridCLR/Jenkins_手动打包测试 打热更")]
    public static void TryHotPackageTest()
    {
        BuildHotPackage();
    }
}