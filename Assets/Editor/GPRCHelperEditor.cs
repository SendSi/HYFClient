﻿using System.Diagnostics;
using System.IO;
using Cysharp.Threading.Tasks;
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
        if (Directory.Exists(destinationPath) == false)
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


    [MenuItem("Tools/luban_excel导表 ^#&l", priority = 1022)]
    public static async void GenerateLuban_binary()
    {
        var lubanBytes = Application.dataPath + @"\GameScript\HotUpdate\Config\lubanBytes";
        if (Directory.Exists(lubanBytes)) Directory.Delete(lubanBytes, true);

        var lubanCodes = Application.dataPath + @"\GameScript\HotUpdate\Config\lubanCodes";
        if (Directory.Exists(lubanCodes)) Directory.Delete(lubanCodes, true);

        var cdPath = Application.dataPath.Replace("Assets", "Excel_luban");
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = $"/C cd /D {cdPath} && gen.bat",//这里很怪 必要先cd到某目录  再去执行bat文件  否则不正常
            UseShellExecute = false,
            RedirectStandardOutput = true,
            CreateNoWindow = true
        };

        Process process = new Process { StartInfo = startInfo };
        process.Start();

        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        if (output.Contains("failed"))
            Debug.LogError($"失败.luban执行成功二进制,数据lubanBytes,代码lubanCodes--,{output}");
        else
            Debug.LogFormat("成功.luban执行二进制,数据lubanBytes,代码lubanCodes--,{0}", output);

         WaitRefresh(100);//若不正常,注释掉
    }


    public async static void WaitRefresh(int frame = 1)
    {
        await UniTask.DelayFrame(frame);
        AssetDatabase.Refresh();
    }
}