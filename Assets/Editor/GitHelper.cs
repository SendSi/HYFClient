using Microsoft.Win32;
using System;
using System.Diagnostics;
using UnityEditor;

public class GitHelper
{
    public static bool StartGitProc(string cmd, string path, string outPath = "")
    {
        string gitProcPath = GetTortoiseGitProcPath();
        if (string.IsNullOrEmpty(gitProcPath))
        {
            UnityEngine.Debug.LogError("TortoiseGitProc未找到");
            return false;
        }

        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = gitProcPath;
        startInfo.Arguments = $"/command:{cmd} /path:\"{path}\"/closeonend:2";

        Process gitProcess = new Process();
        gitProcess.StartInfo = startInfo;
        gitProcess.Start();
        gitProcess.WaitForExit();

        if (gitProcess.ExitCode > 0)
        {
            EditorUtility.DisplayDialog("提示", $"git {cmd} exit with code:{gitProcess.ExitCode}", "确定");

            return false;
        }

        return true;
    }

    public static string GetTortoiseGitProcPath()
    {
        try
        {
            RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
            var path = key.OpenSubKey("SOFTWARE").OpenSubKey("TortoiseGit").GetValue("ProcPath").ToString();
            return path;
        }
        catch (Exception)
        {
            return null;
        }
    }
}
