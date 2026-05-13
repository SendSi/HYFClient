#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.IO;

[InitializeOnLoad]
public static class ViewWinOpenScriptMenu
{
    private const string ViewPrefix = "View_";
    private const string WindowPrefix = "Window_";
    private const string LogicFolder = "Assets/GameScript/HotUpdate/Logic";

    static ViewWinOpenScriptMenu()
    {
        EditorApplication.contextualPropertyMenu += OnContextMenu;
    }

    /// <summary>
    /// 当在 Inspector 中右键点击时触发
    /// </summary>
    private static void OnContextMenu(GenericMenu menu, SerializedProperty property)
    {
        GameObject selectedObject = Selection.activeGameObject;
        if (selectedObject == null)
            return;

        string objectName = selectedObject.name;
        string scriptName = null;

        if (objectName.StartsWith(ViewPrefix))
        {
            scriptName = objectName.Substring(ViewPrefix.Length);
        }
        else if (objectName.StartsWith(WindowPrefix))
        {
            scriptName = objectName.Substring(WindowPrefix.Length) + "Win";
        }
        else
        {
            return;
        }

        if (string.IsNullOrEmpty(scriptName))
            return;

        string scriptPath = FindScriptPath(scriptName);

        if (!string.IsNullOrEmpty(scriptPath))
        {
            menu.AddItem(
                new GUIContent($"打开脚本 ({scriptName})"),
                false,
                () => OpenScript(scriptPath)
            );
        }
        else
        {
            menu.AddDisabledItem(
                new GUIContent($"打开脚本 ({scriptName} - 未找到)")
            );
        }
    }

    /// <summary>
    /// 查找脚本文件路径
    /// </summary>
    private static string FindScriptPath(string scriptName)
    {
        if (Directory.Exists(LogicFolder))
        {
            string[] files = Directory.GetFiles(LogicFolder, "*.cs", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                if (fileName == scriptName)
                {
                    return file.Replace("\\", "/");
                }
            }
        }

        string[] guids = AssetDatabase.FindAssets($"t:MonoScript {scriptName}");
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            string fileName = Path.GetFileNameWithoutExtension(path);
            if (fileName == scriptName)
            {
                return path;
            }
        }

        return null;
    }

    /// <summary>
    /// 使用配置的编辑器打开脚本
    /// </summary>
    private static void OpenScript(string scriptPath)
    {
        Object scriptAsset = AssetDatabase.LoadAssetAtPath<Object>(scriptPath);
        if (scriptAsset != null)
        {
            Selection.activeObject = scriptAsset;
            EditorGUIUtility.PingObject(scriptAsset);
            AssetDatabase.OpenAsset(scriptAsset);
            Debug.Log($"[ViewWinOpenScriptMenu] 已打开脚本: {scriptPath}");
        }
        else
        {
            Debug.LogError($"[ViewWinOpenScriptMenu] 无法加载脚本: {scriptPath}");
        }
    }

    /// <summary>
    /// 通过菜单栏也可以打开当前选中对象的脚本
    /// </summary>
    [MenuItem("GameObject/打开 View 脚本 %#o", priority = 0)]
    private static void OpenViewScriptFromMenu()
    {
        GameObject selectedObject = Selection.activeGameObject;
        if (selectedObject == null)
        {
            Debug.LogWarning("[ViewWinOpenScriptMenu] 请先选择一个 GameObject");
            return;
        }

        string objectName = selectedObject.name;
        string scriptName = null;

        if (objectName.StartsWith(ViewPrefix))
        {
            scriptName = objectName.Substring(ViewPrefix.Length);
        }
        else if (objectName.StartsWith(WindowPrefix))
        {
            scriptName = objectName.Substring(WindowPrefix.Length) + "Win";
        }
        else
        {
            Debug.LogWarning($"[ViewWinOpenScriptMenu] 选中的对象 '{objectName}' 不是以 '{ViewPrefix}' 或 '{WindowPrefix}' 开头");
            return;
        }

        string scriptPath = FindScriptPath(scriptName);

        if (!string.IsNullOrEmpty(scriptPath))
        {
            OpenScript(scriptPath);
        }
        else
        {
            Debug.LogError($"[ViewWinOpenScriptMenu] 未找到脚本: {scriptName}");
        }
    }

    /// <summary>
    /// 菜单项验证
    /// </summary>
    [MenuItem("GameObject/打开脚本 ViewWin  %#o", true)]
    private static bool OpenViewScriptFromMenuValidate()
    {
        GameObject selectedObject = Selection.activeGameObject;
        if (selectedObject == null)
            return false;

        return selectedObject.name.StartsWith(ViewPrefix) || selectedObject.name.StartsWith(WindowPrefix);
    }
}

#endif
