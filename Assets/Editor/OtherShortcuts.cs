using UnityEngine;
using UnityEditor;

public class OtherShortcuts
{
    [MenuItem("Tools/设置显隐Active %#d", false, 0)]
    static void ToggleSelectedObjectsActiveState()
    {
        if (Selection.gameObjects.Length == 0)
        {
            Debug.LogWarning("No objects selected in Hierarchy");
            return;
        }

        Undo.RecordObjects(Selection.gameObjects, "Toggle Active State");

        foreach (GameObject obj in Selection.gameObjects)
        {
            if (obj != null)
            {
                obj.SetActive(!obj.activeSelf);
            }
        }
    }

    [MenuItem("Tools/刷新启动_停止 _F12")]
     static void RefreshStartStop()
    {
        if (EditorApplication.isPlaying)
        {
            EditorApplication.ExecuteMenuItem("Edit/Play");
        }
        else
        {
            AssetDatabase.Refresh();
            EditorApplication.ExecuteMenuItem("Edit/Play");
        }
    }
}