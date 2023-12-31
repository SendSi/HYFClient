using UnityEditor;
using UnityEngine;
#region << 脚 本 注 释 >>
//作  用:    
//作  者:    
//创建时间:  2023

//string[] guids = AssetDatabase.FindAssets("t:scene Game" , null);
//string scenePath = AssetDatabase.GUIDToAssetPath(guids[0]);
//Debug.Log(scenePath);
#endregion


[InitializeOnLoad]
public class PlaySideButton
{

    static PlaySideButton()
    {
        UnityEditorToolbar.RightToolbarGUI.Add(OnRightToolbarGUI);
        UnityEditorToolbar.LeftToolbarGUI.Add(OnLeftToolbarGUI);
    }

    private static void OnLeftToolbarGUI()
    {
        GUILayout.FlexibleSpace();//从右开始排
        if (GUILayout.Button("更新_*_日志", GUILayout.MaxWidth(80), GUILayout.Height(21)))
        {
            if (Application.isPlaying)
            {
                Debug.LogError("你游戏正在运行中");
                return;
            }
            var cmd = Event.current.button == 0 ? "pull" : "log";
            string projectRootPath = System.IO.Path.GetDirectoryName(Application.dataPath);
            GitHelper.StartGitProc(cmd, projectRootPath);///Application.dataPath);
        }
    }


    static void OnRightToolbarGUI()
    {
        if (GUILayout.Button("提交_*_推送", GUILayout.Width(80), GUILayout.Height(21)))
        {
            if (Application.isPlaying)
            {
                Debug.LogError("你游戏正在运行中");
                return;
            }
            var cmd = Event.current.button == 0 ? "commit" : "push";
            string projectRootPath = System.IO.Path.GetDirectoryName(Application.dataPath);
            GitHelper.StartGitProc(cmd, projectRootPath);
        }

    }
}
