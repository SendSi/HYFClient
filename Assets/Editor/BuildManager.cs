using UnityEditor;
using UnityEngine;
#region << 脚 本 注 释 >>
//作  用:    BuildManager
//作  者:    曾思信
//创建时间:  #CREATETIME#
#endregion


public class BuildManager : EditorWindow
{

    [MenuItem("BuildManager/BuildAPK")]
    static void BuildAPK()
    {
        BuildPlayerOptions options = new BuildPlayerOptions();
        string[] scenePath = new string[EditorBuildSettings.scenes.Length];
        var buildIndex = 0;
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            scenePath[buildIndex] = scene.path;
            buildIndex++;
        }
        options.scenes = scenePath;
        options.locationPathName = Application.dataPath + "/../Build/Demo.apk";
        options.target = BuildTarget.Android;
        options.options = BuildOptions.None;
        BuildPipeline.BuildPlayer(options);
    }
}