using System.IO;
using HybridCLR.Editor.Settings;
using UnityEditor;

public static class CLRHelperEditor
{
    [MenuItem("HybridCLR/Copy_replace_dlls_to_bytes")] //打了热更后  替换
    public static void CopyAotDll()
    {
        BuildTarget target = EditorUserBuildSettings.activeBuildTarget;
        string fromDir = Path.Combine(HybridCLRSettings.Instance.strippedAOTDllOutputRootDir, target.ToString());
        string toDir = "Assets/GameResHotFix";
        if (Directory.Exists(toDir))
        {
            Directory.Delete(toDir, true);//先删除  再copy
        }

        Directory.CreateDirectory(toDir);
        AssetDatabase.Refresh();
//1//aot
        var list = AOTGenericReferences.PatchedAOTAssemblyList;
        foreach (string aotDll in list)
        {
            File.Copy(Path.Combine(fromDir, aotDll), Path.Combine(toDir, $"{aotDll}.bytes"), true);
        }

//2//热更
        var hotUpdate = "HotUpdate.dll";
        string fromDirHot = Path.Combine(HybridCLRSettings.Instance.hotUpdateDllCompileOutputRootDir, target.ToString());
        File.Copy(Path.Combine(fromDirHot, hotUpdate), Path.Combine(toDir, $"{hotUpdate}.bytes"), true);

        AssetDatabase.Refresh();
    }
}