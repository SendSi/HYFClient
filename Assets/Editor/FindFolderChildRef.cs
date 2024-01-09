using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using Path = System.IO.Path;

public class FindFolderChildRef : EditorWindow
{
    string mInputTxt = @"Assets\GameRes\Effect";
    bool mIsDeleteNone = false;

    [MenuItem("Tools/辅助工具/查引用文件夹(子文件的引用)")]
    public static void CreateUsageCheckerWindow()
    {
        EditorWindow.GetWindow<FindFolderChildRef>("文件夹(子文件的引用)");
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("输入的最小文件夹,查询的是子文件引用,\r\n因项目资源多,查询耗时长,请在饭点操作吧", GUILayout.MinHeight(50));
        EditorGUILayout.Space(5);
        mInputTxt = EditorGUILayout.TextField(mInputTxt, GUILayout.MinWidth(200), GUILayout.MinHeight(22));

        EditorGUILayout.Space(8);
        EditorGUILayout.BeginHorizontal("Box");
        EditorGUILayout.LabelField("结合 另一工具,[[Tools/辅助工具/Miss引用 辅助工具]],可知Prefab的引用是否删错了,若删错了,会Miss的", GUILayout.MinWidth(350));
        if (GUILayout.Button("打开", GUILayout.MaxWidth(50)))
        {
            EditorApplication.ExecuteMenuItem("Tools/辅助工具/Miss引用 辅助工具");
        }
        EditorGUILayout.EndHorizontal();
        mIsDeleteNone = EditorGUILayout.Toggle("是否删除无引用的", mIsDeleteNone);

        EditorGUILayout.Space(8);
        if (GUILayout.Button("查询文件夹的子文件引用_耗时长", GUILayout.MinHeight(30)))
        {
            CheckFolderUsage(mInputTxt); // 替换为要检查的文件夹路径          
        }
    }

    void CheckFolderUsage(string folderPath)
    {
        string[] assetPaths = AssetDatabase.FindAssets("", new[] { folderPath });
        var guidDics = new Dictionary<string, string>();
        var filePathDics = new Dictionary<string, string>();
        var hasRefDic = new Dictionary<string, bool>();
        var count = 0;
        foreach (string guid in assetPaths)
        {
            string fullPath = AssetDatabase.GUIDToAssetPath(guid);
            string fileName = Path.GetFileNameWithoutExtension(fullPath);
            if (guidDics.ContainsKey(guid) == false)
            {
                guidDics[guid] = fileName;

                hasRefDic[fileName] = false;

                filePathDics[fileName] = fullPath;
                count++;
            }
        }

        var bottomLog = "{0}在{1}查找中";
        var topLog = "查找引用中(*.prefab,*.unity,*.mat,*.asset)_{0}/{1}_结果看Console";
        var indexFind = 0;
        var files = GetAllDic();
        foreach (var guidItem in guidDics)
        {
            for (int i = 0; i < files.Length; i++)
            {
                if (hasRefDic[guidItem.Value] == true)
                {
                    break;
                }

                string file = files[i];
                if (i % 20 == 0)
                {
                    bool isCancel = EditorUtility.DisplayCancelableProgressBar(string.Format(topLog, indexFind, count), string.Format(bottomLog, guidItem.Value, Path.GetFileNameWithoutExtension(file)), (float)i / (float)files.Length);
                    if (isCancel)
                    {
                        break;
                    }
                }
                if (hasRefDic[guidItem.Value] == false && Regex.IsMatch(File.ReadAllText(file), guidItem.Key))
                {
                    hasRefDic[guidItem.Value] = true;
                }
            }
            indexFind++;
        }


        var noneRef = 0;
        StringBuilder sbItem = new StringBuilder();
        foreach (var item in hasRefDic)
        {
            if (item.Value == false)
            {
                sbItem.Append(item.Key + " ; ");
                noneRef++;
            }
        }
        var strLog = mInputTxt + "目录下,共计未引用有" + noneRef + "个,分别是:" + sbItem.ToString();
        EditorGUIUtility.systemCopyBuffer = strLog;
        Debug.LogError(strLog);
        EditorUtility.ClearProgressBar();

        if (mIsDeleteNone)
        {
            foreach (var item in hasRefDic)
            {
                if (item.Value == false)
                {
                    if (File.Exists(filePathDics[item.Key]))
                    {
                        File.Delete(filePathDics[item.Key]);
                    }
                }
            }
            ShowNotification(new GUIContent("查找的结果,已copy到剪切板了,可看console_Log,也删了无引用的"));
            AssetDatabase.Refresh();
        }
        else
        {
            ShowNotification(new GUIContent("查找的结果,已copy到剪切板了,请看console_Log"));
        }
    }

    static string[] allDic;
    static string[] GetAllDic()
    {
        if (allDic == null || allDic.Length <= 0)
        {
            var withoutExtentsions = new List<string>() { ".prefab", ".unity", ".mat", ".asset" };
            allDic = Directory.GetFiles(Application.dataPath, "*.*", SearchOption.AllDirectories).Where(s => withoutExtentsions.Contains(Path.GetExtension(s).ToLower())).ToArray();
        }
        return allDic;
    }

}
