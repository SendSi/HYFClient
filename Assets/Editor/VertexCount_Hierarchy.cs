//@Description: Hierarchy面板顶点排行
//@Author: 曾思信
//@Date: Created in 2022/
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VertexCount_Hierarchy : EditorWindow
{

    [MenuItem("Tools/辅助工具/查看顶点排行_Hierarchy", false, 9999)]
    public static void ShowVertex_Playing()
    {
        EditorWindow.GetWindow(typeof(VertexCount_Hierarchy)); //>(false,"",true);
    }

    private bool mIsHasFGUIVert = false;//true需要显示fgui顶点
    private Vector2 mLookV2;
    List<UnityEngine.GameObject> mAllMesh;
    Dictionary<GameObject, string> mDicNoGos = new Dictionary<GameObject, string>();
    private void OnGUI()
    {
        mIsHasFGUIVert = EditorGUILayout.Toggle("含FGUI的顶点信息", mIsHasFGUIVert);
        if (GUILayout.Button("   加载显示   Hierarchy面板的顶点排行", GUILayout.Height(30)))
        {
            var tmpObj = FindObjectsOfType(typeof(GameObject)) as GameObject[];
            mAllMesh = new List<GameObject>();
            for (int i = 0; i < tmpObj.Length; i++)
            {
                if (GetIsNeedShowMesh(tmpObj[i]))
                {
                    mAllMesh.Add(tmpObj[i]);
                }
            }

            mAllMesh.Sort((a, b) =>
            {
                var aCount = GetMeshVertCount(a);
                var bCount = GetMeshVertCount(b);
                if (aCount > bCount)
                    return -1;
                return 1;
            });
            mDicNoGos = new Dictionary<GameObject, string>();
            int tVer;
            int tTri;
            int tCountVer = 0;
            int tCountTri = 0;
            for (int i = 0; i < mAllMesh.Count; i++)
            {
                if (mDicNoGos.ContainsKey(mAllMesh[i]) == false)
                {
                    tVer = GetMeshVertCount(mAllMesh[i]);
                    tTri = GetMeshTrianglesCount(mAllMesh[i]);
                    mDicNoGos[mAllMesh[i]] = "  顶点数:" + tVer + ",面数:" + tTri;
                    tCountVer = tCountVer + tVer;
                    tCountTri = tCountTri + tTri;
                }
            }
            string str;
            if (mIsHasFGUIVert == true)
                str = ("共计有" + mDicNoGos.Count + "个 含有MeshFilter,\r\n这一屏共计" + tCountVer + "个顶点," + tCountTri + "个面,已排序--(过滤顶点>0)");
            else
                str = ("共计有" + mDicNoGos.Count + "个 含有MeshFilter,\r\n这一屏共计" + tCountVer + "个顶点," + tCountTri + "个面,已排序--(过滤顶点>0且非fgui)");


            this.ShowNotification(new GUIContent(str), 2);
            Debug.LogError(str);
        }

        mLookV2 = GUILayout.BeginScrollView(mLookV2);
        if (mAllMesh != null && mAllMesh.Count > 0)
        {
            foreach (var item in mDicNoGos)
            {
                if (item.Key != null && GUILayout.Button(item.Key.name + item.Value))
                {
                    Selection.activeObject = item.Key;
                }
            }
        }
        GUILayout.EndScrollView();
    }

    int GetMeshVertCount(GameObject go)
    {
        var mesh = go?.GetComponent<MeshFilter>();
        if (mesh != null && mesh.sharedMesh != null)
        {
            return mesh.sharedMesh.vertexCount;

        }
        return 0;
    }

    int GetMeshTrianglesCount(GameObject go)
    {
        var mesh = go?.GetComponent<MeshFilter>();
        if (mesh != null && mesh.sharedMesh != null)
        {
            return mesh.sharedMesh.triangles.Length / 3;

        }
        return 0;
    }

    bool GetIsNeedShowMesh(GameObject go)
    {
        var mesh = go?.GetComponent<MeshFilter>();
        if (mesh != null && mesh.mesh != null)
        {
            var ver = mesh.sharedMesh.vertexCount;
            if (mIsHasFGUIVert == true && ver > 0)
            {
                return true;
            }
            else if (mIsHasFGUIVert == false && ver > 0)
            {
                var name = mesh.mesh.name;
                if (name.Contains("Image") || name.Contains("TextField") || name.Contains("Shape"))
                {
                    return false;
                }
                return true;
            }
        }
        return false;
    }
}
