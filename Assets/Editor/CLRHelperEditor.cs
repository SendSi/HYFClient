using System.IO;
using HybridCLR.Editor.Settings;
using UnityEditor;
using UnityEngine;
using HybridCLR.Editor;
using HybridCLR.Editor.Commands;
using Obfuz.Settings;
using Obfuz4HybridCLR;
using System.Collections.Generic;

public static class CLRHelperEditor
{
    
    
    public const string menuDLLCopy = "HybridCLR/Generate/All_CopyTo_GameResHotFix";

    [MenuItem(menuDLLCopy, false, 5000)] //打了热更后  替换
    public static void CopyAotDll()
    {
        BuildTarget target = EditorUserBuildSettings.activeBuildTarget;
        string fromDir = Path.Combine(HybridCLRSettings.Instance.strippedAOTDllOutputRootDir, target.ToString());
        Debug.Log("将AOT和热更dll拷贝到[Assets/GameResHotFix]目录下-->formDir=" + fromDir);
        string toDir = "Assets/GameResHotFix";
        if (Directory.Exists(toDir))
        {
            Directory.Delete(toDir, true); //先删除  再copy
        }
        Directory.CreateDirectory(toDir);
        AssetDatabase.Refresh();

        //1aot
        var list = AOTGenericReferences.PatchedAOTAssemblyList;
        foreach (string aotDll in list)
        {
            File.Copy(Path.Combine(fromDir, aotDll), Path.Combine(toDir, $"{aotDll}.bytes"), true);
        }

        //2热更
        var hotUpdate = "HotUpdate.dll";
        string fromDirHot = Path.Combine(HybridCLRSettings.Instance.hotUpdateDllCompileOutputRootDir, target.ToString());
        File.Copy(Path.Combine(fromDirHot, hotUpdate), Path.Combine(toDir, $"{hotUpdate}.bytes"), true);

        //3pdb 为输入堆栈使用的
        var hotPDB = "HotUpdate.pdb";
        File.Copy(Path.Combine(fromDirHot, hotPDB), Path.Combine(toDir, $"{hotPDB}.bytes"), true);

        AssetDatabase.Refresh();
    }


    [MenuItem("HybridCLR/ObfuzExtension/GenerateAll_CopyTo_GameResHotFix")]
    public static void CompileAndObfuscateAndCopyToStreamingAssets()
    {
        BuildTarget target = EditorUserBuildSettings.activeBuildTarget;
        CompileDllCommand.CompileDll(target);

        string obfuscatedHotUpdateDllPath = PrebuildCommandExt.GetObfuscatedHotUpdateAssemblyOutputPath(target);
        ObfuscateUtil.ObfuscateHotUpdateAssemblies(target, obfuscatedHotUpdateDllPath);

        Directory.CreateDirectory(Application.streamingAssetsPath);

        string hotUpdateDllPath = $"{SettingsUtil.GetHotUpdateDllsOutputDirByTarget(target)}";
        List<string> obfuscationRelativeAssemblyNames = ObfuzSettings.Instance.assemblySettings.GetObfuscationRelativeAssemblyNames();
        string toDir = "Assets/GameResHotFix";

        foreach (string assName in SettingsUtil.HotUpdateAssemblyNamesIncludePreserved)
        {
            string srcDir = obfuscationRelativeAssemblyNames.Contains(assName) ? obfuscatedHotUpdateDllPath : hotUpdateDllPath;
            string srcFile = $"{srcDir}/{assName}.dll";
            string dstFile = Path.Combine(toDir, $"{assName}.dll.bytes");

            if (File.Exists(srcFile))
            {
                File.Copy(srcFile, dstFile, true);
                Debug.LogError($"[复制]   源:{srcFile} ，，，目标:{dstFile}");
            }
        }
       AssetDatabase.Refresh();
    }
}