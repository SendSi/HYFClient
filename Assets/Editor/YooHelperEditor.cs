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

    [MenuItem("YooAsset/Clear清空_WWW_hyfclient")] //打了热更后  替换
    public static void ClearCDNPath()
    {
        var toDir = $"{AppConfig.localCDN}{GetPlatform()}/{AppConfig.appVersion}";
        Debug.Log("若无报错 则成功删除       将删除="+toDir);
        if (Directory.Exists(toDir))
        {
            Directory.Delete(toDir, true); //先删除  
        }

        AssetDatabase.Refresh();
    }


    [MenuItem("YooAsset/Copy到_WWW_hyfclient")] //打了热更后  替换
    public static void CopyCDNPath()
    {
        var targetPath = $"{AppConfig.localCDN}{GetPlatform()}/{AppConfig.appVersion}";
        if (Directory.Exists(targetPath) == false)
        {
            Directory.CreateDirectory(targetPath); //先删除  再copy
        }
        var formRoot = $"{YooAsset.Editor.AssetBundleBuilderHelper.GetDefaultBuildOutputRoot()}/{UnityEditor.EditorUserBuildSettings.activeBuildTarget}";
        
        var soreceList = new List<string>();
        string resVerPath = "";
        foreach (var item in AssetBundleCollectorSettingData.Setting.Packages)
        {
            resVerPath= $"{formRoot}/{item.PackageName}/{AppConfig.resVersion}";
            soreceList.Add(resVerPath);
            Debug.Log($"formRoot={resVerPath}");
            if (Directory.Exists(resVerPath) == false)
            {
                Debug.LogError($"不存在此路径={resVerPath},请先打包资源 或看看AppConfig.resVersion是否正确");
                return;
            }
        }

        //Debuger.LogError($"formRoot:{formRoot} -->     targetPath: {targetPath}");
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
        Debug.Log(" http-server --port 80 -b --cors       已copy    若无报错 则成功  ");
        GUIUtility.systemCopyBuffer = "http-server --port 80 -b --cors";
        System.Diagnostics.Process.Start(AppConfig.localCDN.Replace("CDN",""));
    }
}