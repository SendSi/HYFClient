using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
#region << 脚 本 注 释 >>
//作  用:    FindReferences
//作  者:    曾思信
//创建时间:  2023/06/25 17:02
#endregion

public class FindReferences
{
    static bool mIsHasRef = false;
    [MenuItem("Assets/Find References(查引用)", false, 10)]
    static void Find()
    {
        var guidDics = new Dictionary<string, string>();
        foreach (Object item in Selection.objects)
        {
            string path = AssetDatabase.GetAssetPath(item);
            if (string.IsNullOrEmpty(path) == false)
            {
                string guid = AssetDatabase.AssetPathToGUID(path);
                if (guidDics.ContainsKey(guid) == false)
                {
                    guidDics[guid] = item.name;
                }
            }
        }
        if (guidDics.Count > 0)
        {
            Debug.LogError("查找引用 开始");
            mIsHasRef = false;
            var withoutExtentsions = new List<string>() { ".prefab", ".unity", ".mat", ".asset" };
            string[] files = Directory.GetFiles(Application.dataPath, "*.*", SearchOption.AllDirectories).Where(s => withoutExtentsions.Contains(Path.GetExtension(s).ToLower())).ToArray();
            for (int i = 0; i < files.Length; i++)
            {
                string file = files[i];
                if (i % 20 == 0)
                {
                    bool isCancel = EditorUtility.DisplayCancelableProgressBar("查找引用中(*.prefab,*.unity,*.mat,*.asset)__结果看Console", file, (float)i / (float)files.Length);
                    if (isCancel)
                    {
                        break;
                    }
                }
                foreach (var guidItem in guidDics)
                {
                    if (Regex.IsMatch(File.ReadAllText(file), guidItem.Key))
                    {
                        mIsHasRef = true;
                        Debug.Log("查找的是=" + guidItem.Value + ",引用者=" + AssetDatabase.LoadAssetAtPath<Object>(GetRelativeAssetsPath(file)) + ",文件路径=" + file);
                    }
                }
            }
            EditorUtility.ClearProgressBar();
            if (mIsHasRef)
            {
                Debug.LogError("查找引用 结束");
            }
            else
            {
                Debug.LogError("查找引用 结束,并无引用,请考虑删除否");
            }
        }
    }

    [MenuItem("Assets/Find References(查引用)", true)]
    static bool VFind()
    {
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        return (string.IsNullOrEmpty(path) == false);
    }

    private static string GetRelativeAssetsPath(string file)
    {
        return "Assets" + Path.GetFullPath(file).Replace(Path.GetFullPath(Application.dataPath), "").Replace("\\", "/");
    }
}
