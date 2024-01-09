using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using YooAsset.Editor;

//对yooAsset不熟 先手动写死吧
public class YooHelperEditor : MonoBehaviour
{
    static string GetPlatform()
    {
        if (UnityEditor.EditorUserBuildSettings.activeBuildTarget == BuildTarget.Android)
            return "Android";
        else if (UnityEditor.EditorUserBuildSettings.activeBuildTarget == BuildTarget.iOS)
            return "IPhone";
        else if (UnityEditor.EditorUserBuildSettings.activeBuildTarget == BuildTarget.WebGL)
            return "WebGL";
        else
            return "PC";
    }

    [MenuItem("YooAsset/ClearWWW_清空文件夹")] //打了热更后  替换
    public static void ClearCDNPath()
    {
        var toDir = $"{AppConfig.localCDN}{GetPlatform()}/{AppConfig.appVersion}";
        if (Directory.Exists(toDir))
        {
            Directory.Delete(toDir, true); //先删除  再copy
        }

        AssetDatabase.Refresh();
        Debug.Log("无报错 则成功");
    }


    [MenuItem("YooAsset/CopyWWW_复制")] //打了热更后  替换
    public static void CopyCDNPath()
    {
        var targetPath = $"{AppConfig.localCDN}{GetPlatform()}/{AppConfig.appVersion}";
        if (Directory.Exists(targetPath) == false)
        {
            Directory.CreateDirectory(targetPath); //先删除  再copy
        }

        var formRoot = $"{YooAsset.Editor.AssetBundleBuilderHelper.GetDefaultBuildOutputRoot()}/{UnityEditor.EditorUserBuildSettings.activeBuildTarget}";
        var soreceList = new List<string>();
        foreach (var item in AssetBundleCollectorSettingData.Setting.Packages)
        {
            soreceList.Add($"{formRoot}/{item.PackageName}/{AppConfig.resVersion}");
        }

        //Debug.LogError($"formRoot:{formRoot} -->     targetPath: {targetPath}");
        for (int i = 0; i < soreceList.Count; i++)
        {
            foreach (string filePath in Directory.GetFiles(soreceList[i]))
            {
                string fileName = Path.GetFileName(filePath);
                string destinationPath = Path.Combine(targetPath, fileName);
                File.Copy(filePath, destinationPath, true); // 如果目标文件已经存在，覆盖
            }
        }
        

        AssetDatabase.Refresh();
        Debug.Log("无报错 则成功      http-server --port 80 -b --cors       已copy");
        GUIUtility.systemCopyBuffer = "http-server --port 80 -b --cors";
        System.Diagnostics.Process.Start(AppConfig.localCDN.Replace("CDN",""));
    }
}