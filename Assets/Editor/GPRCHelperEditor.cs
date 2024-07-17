using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

//HFYClient与HFYServer   从gitHub down下来 得同一目录哦
public class GPRCHelperEditor
{
    public static string RootPath => Path.GetDirectoryName(Application.dataPath);
    public static string ToolkitPath => Path.Combine(RootPath, "Toolkit");

    [MenuItem("Tools/grpc_生成协议", priority = 100)]
    public static void GenerateProtocol()
    {
        var toolkitPath = ToolkitPath;
        var destinationPath = Path.Combine(Application.dataPath, "GameScript/HotUpdate/Protols");
        if (Directory.Exists(destinationPath)==false)
        {
            Directory.CreateDirectory(destinationPath);
        }

        var batPath = Path.Combine(toolkitPath, "ProtoGen.bat");

        Process process = new Process();
        process.StartInfo.FileName = batPath;
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.ArgumentList.Add(toolkitPath);
        process.StartInfo.ArgumentList.Add(destinationPath);
        process.Start();

        // 等待批处理文件执行完成
        process.WaitForExit();

        if (process.ExitCode == 0)
        {
            AssetDatabase.Refresh();
            Debuger.Log("生成协议完成");
        }
        else
        {
            Debuger.LogError($"生成协议失败. code:{process.ExitCode}, msg:{process.StandardError.ReadToEnd()}");
        }
    }
    
    // [MenuItem("Tools/luban_导表二进制", priority = 101)]
    // public static void GenerateLuban_binary()
    // {
    //     var batFilePath = Application.dataPath.Replace("Assets", "Excel_luban/gen.bat");
    //
    //     Debug.LogError(batFilePath);
    //     
    //     Process process = new Process();
    //     process.StartInfo.FileName = batFilePath;
    //     process.StartInfo.CreateNoWindow = true;
    //     process.StartInfo.UseShellExecute = false;
    //     process.StartInfo.RedirectStandardOutput = true;
    //     process.StartInfo.RedirectStandardError = true;
    //     process.Start();
    //     Debug.LogError("???");
    //     
    //     // if (process.ExitCode == 0)
    //     // {
    //     //     AssetDatabase.Refresh();
    //     //     Debug.Log("luban_导表二进制 完成");
    //     // }
    //     // else
    //     // {
    //     //     Debug.LogError($"luban_导表二进制. code:{process.ExitCode}, msg:{process.StandardError.ReadToEnd()}");
    //     // }
    //     // // Wait for the batch file to finish executing
    //     // process.WaitForExit();
    // }
}