#if UNITY_EDITOR
using UnityEditor;
using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

/// <summary> Jenkins 打包命令</summary>
public class Jenkins2Unity : EditorWindow
{
    private string scriptAppVersion = "v1.0.0";
    private string scriptResVersion = "v1.0.0";
    private string scriptPlayMode = "OfflinePlayMode";

    private string editAppVersion = "v1.0.0";
    private string editResVersion = "v1.0.0";
    private int editPlayModeIndex = 0;
    private int buildTypeIndex = 0;

    private readonly string[] playModeOptions = new string[] { "OfflinePlayMode", "HostPlayMode" };
    private readonly string[] buildTypeOptions = new string[] { "出包", "出热更" };

    private const string AppConfigPath = @"Assets/GameScript/AOT/AppConfig.cs";

    [MenuItem("Jenkins/使用Unity出", priority = 200)]
    public static void ShowNetTool()
    {
        var win = GetWindow<Jenkins2Unity>("使用Unity出");
        win.minSize = new Vector2(400, 350);
        win.Show();
    }

    private void OnEnable()
    {
        LoadFromAppConfig();
    }

    private void OnGUI()
    {
        EditorGUILayout.Space(5);

        EditorGUILayout.LabelField("AppConfig.cs当前配置预览：", EditorStyles.boldLabel);
        EditorGUILayout.HelpBox(
            $"PlayMode: {scriptPlayMode}\n" +
            $"AppVersion: {scriptAppVersion}\n" +
            $"ResVersion: {scriptResVersion}",
            MessageType.Info
        );

        EditorGUILayout.Space(15);
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        EditorGUILayout.Space(10);

        EditorGUILayout.LabelField("修改配置：", EditorStyles.boldLabel);
        EditorGUILayout.Space(5);

        EditorGUILayout.LabelField("打包类型", EditorStyles.boldLabel);
        buildTypeIndex = EditorGUILayout.Popup(buildTypeIndex, buildTypeOptions);
        EditorGUILayout.Space(5);

        // 只有选择"出包"时才显示 AppVersion 和 ResVersion
        if (buildTypeIndex == 0)
        {

            EditorGUILayout.LabelField("PlayMode", EditorStyles.boldLabel);
            editPlayModeIndex = EditorGUILayout.Popup(editPlayModeIndex, playModeOptions);
            EditorGUILayout.Space(5);

            EditorGUILayout.LabelField("AppVersion", EditorStyles.boldLabel);
            editAppVersion = EditorGUILayout.TextField(editAppVersion);
            EditorGUILayout.Space(5);
        }

        EditorGUILayout.LabelField("ResVersion", EditorStyles.boldLabel);
        editResVersion = EditorGUILayout.TextField(editResVersion);
        EditorGUILayout.Space(5);

        EditorGUILayout.Space(20);

        if (GUILayout.Button("保存配置", GUILayout.Height(28)))
        {
            SaveToAppConfig();
            ShowNotification(new GUIContent("配置已保存！"));
        }

        EditorGUILayout.Space(5);

        GUIStyle buildButtonStyle = new GUIStyle(GUI.skin.button)
        {
            fontSize = 14,
            fontStyle = FontStyle.Bold,
            normal = { textColor = Color.white },
            hover = { textColor = Color.white }
        };

        string buttonText = buildTypeIndex == 0 ? "确认且出包" : "确认且出热更";
        if (GUILayout.Button(buttonText, buildButtonStyle, GUILayout.Height(35)))
        {
            SaveAndBuild();
        }
    }

    /// <summary> 从AppConfig.cs读取配置 </summary>
    private void LoadFromAppConfig()
    {
        string fullPath = Path.Combine(Application.dataPath, "../", AppConfigPath);
        fullPath = Path.GetFullPath(fullPath);

        if (!File.Exists(fullPath))
        {
            Debug.LogError($"AppConfig.cs 不存在：{fullPath}");
            return;
        }

        string content = File.ReadAllText(fullPath);

        // 读取 appVersion -> scriptAppVersion（只读显示）
        Match appVersionMatch = Regex.Match(content,
            @"public\s+static\s+string\s+appVersion\s*=\s*""([^""]*)""\s*;");
        if (appVersionMatch.Success)
        {
            scriptAppVersion = appVersionMatch.Groups[1].Value;
            editAppVersion = scriptAppVersion; // 可编辑区初始值与脚本同步
        }

        // 读取 resVersion -> scriptResVersion（只读显示）
        Match resVersionMatch = Regex.Match(content,
            @"public\s+static\s+string\s+resVersion\s*=\s*""([^""]*)""\s*;");
        if (resVersionMatch.Success)
        {
            scriptResVersion = resVersionMatch.Groups[1].Value;
            editResVersion = scriptResVersion; // 可编辑区初始值与脚本同步
        }

        // 读取 playModeStr -> scriptPlayMode（只读显示）
        Match playModeMatch = Regex.Match(content,
            @"public\s+static\s+YooAsset\.EPlayMode\s+playModeStr\s*=\s*(YooAsset\.EPlayMode\.)?(\w+)\s*;");
        if (playModeMatch.Success)
        {
            scriptPlayMode = playModeMatch.Groups[2].Value;
            editPlayModeIndex = Array.IndexOf(playModeOptions, scriptPlayMode);
            if (editPlayModeIndex < 0) editPlayModeIndex = 0;
        }

        Debug.Log($"[Jenkins2Unity] 已读取配置: appVersion={scriptAppVersion}, resVersion={scriptResVersion}, playMode={scriptPlayMode}");
    }

    /// <summary> 保存配置到AppConfig.cs </summary>
    private void SaveToAppConfig()
    {
        string fullPath = Path.Combine(Application.dataPath, "../", AppConfigPath);
        fullPath = Path.GetFullPath(fullPath);

        if (!File.Exists(fullPath))
        {
            Debug.LogError($"AppConfig.cs 不存在：{fullPath}");
            return;
        }

        string content = File.ReadAllText(fullPath);
        string newPlayMode = playModeOptions[editPlayModeIndex];

        // 只有出包时才修改 appVersion
        if (buildTypeIndex == 0)
        {
            content = Regex.Replace(content,
                @"public\s+static\s+string\s+appVersion\s*=\s*""[^""]*""\s*;",
                $"public static string appVersion = \"{editAppVersion}\";",
                RegexOptions.Multiline
            );
            scriptAppVersion = editAppVersion;
        }

        // 替换 resVersion
        content = Regex.Replace(content,
            @"public\s+static\s+string\s+resVersion\s*=\s*""[^""]*""\s*;",
            $"public static string resVersion = \"{editResVersion}\";",
            RegexOptions.Multiline
        );

        // 替换 playModeStr
        content = Regex.Replace(content,
            @"public\s+static\s+YooAsset\.EPlayMode\s+playModeStr\s*=\s*YooAsset\.EPlayMode\.\w+\s*;",
            $"public static YooAsset.EPlayMode playModeStr = YooAsset.EPlayMode.{newPlayMode};",
            RegexOptions.Multiline
        );

        File.WriteAllText(fullPath, content);
        AssetDatabase.Refresh();

        // 保存后更新脚本显示的原始值
        scriptResVersion = editResVersion;
        scriptPlayMode = newPlayMode;

        if (buildTypeIndex == 0)
        {
            Debug.Log($"[Jenkins2Unity] 已保存配置: appVersion={editAppVersion}, resVersion={editResVersion}, playMode={newPlayMode}");
        }
        else
        {
            Debug.Log($"[Jenkins2Unity] 已保存配置: resVersion={editResVersion}, playMode={newPlayMode}");
        }
    }

    /// <summary> 保存配置并调用打包 </summary>
    private void SaveAndBuild()
    {
        SaveToAppConfig();

        // 根据打包类型构建确认信息
        string message;
        if (buildTypeIndex == 0)
        {
            message = $"即将开始出包，配置如下：\n\n" +
                      $"PlayMode: {playModeOptions[editPlayModeIndex]}\n" +
                      $"AppVersion: {editAppVersion}\n" +
                      $"ResVersion: {editResVersion}\n\n" +
                      $"是否继续？";
        }
        else
        {
            message = $"即将开始出热更，配置如下：\n\n" +
                        $"ResVersion: {editResVersion}\n\n" +
                      $"是否继续？";
        }

        bool confirm = EditorUtility.DisplayDialog(
            buildTypeIndex == 0 ? "确认出包" : "确认出热更",
            message,
            "确认",
            "取消"
        );

        if (confirm)
        {
            if (buildTypeIndex == 0)
            {
                Debug.Log("[Jenkins2Unity] 开始调用出包流程...");
                JenkinsCommand.JenkinsBuildTarget();
            }
            else
            {
                Debug.Log("[Jenkins2Unity] 开始调用出热更流程...");
                JenkinsCommand.JenkinsBuildHotPKG();
            }
        }
        else
        {
            Debug.Log("[Jenkins2Unity] 用户取消操作");
        }
    }
}

#endif
