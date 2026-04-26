using UnityEditor;
using UnityEngine;
using System;
using System.Linq;

public static class JenkinsBuild
{
    // 命令行里要调用的就是这个方法
    public static void BuildApk()
    {
        Debug.Log("=== Jenkins 打包开始 ===");

        // 1. 读取 Jenkins 参数（可选）
        string version = Environment.GetEnvironmentVariable("VERSION") ?? "1.0.0";
        string channel = Environment.GetEnvironmentVariable("CHANNEL") ?? "default";

        // 2. 设置版本号
        PlayerSettings.bundleVersion = version;
        PlayerSettings.applicationIdentifier = $"com.HYFClient.ML";

        // 3. 配置打包选项
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

        // 4. 开始打包
        BuildPipeline.BuildPlayer(options);
        Debug.Log($"=== Jenkins 打包完成，输出路径：{outputPath} ===");
    }
    
    [MenuItem("HybridCLR/Jenkins_手动打包测试_仅出apk")]
    public static void TryBuildTest()
    {
        BuildApk();
    }
}