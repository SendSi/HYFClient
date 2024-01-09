//@Description: 脚本描述
//@Author: 曾思信
//@Date: Created in 2022/

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MEditor
{
    public class VertexCount_Project : AssetBaseHelper
    {

        [MenuItem("Tools/辅助工具/查看顶点排行_Project",false,9999)]
        public static void ShowVertex() 
        {
            EditorWindow.GetWindow(typeof(VertexCount_Project)); //>(false,"",true);
        }

       

        private bool mIsPrefab = false;//
        private Vector2 mLookV2;

        public List<UnityEngine.GameObject> FindOneGos(string filterName)
        {
            //var tGuids = AssetDatabase.FindAssets("t:Mesh MiddleCity_01", new string[] { "Assets" });
            var tGuids = AssetDatabase.FindAssets("t:" + filterName, new string[] { "Assets" });
            UnityEngine.GameObject tGo = null;
            List<UnityEngine.GameObject> tAllMesh = new List<UnityEngine.GameObject>();
            foreach (var guid in tGuids)
            {
                tGo = AssetDatabase.LoadMainAssetAtPath(AssetDatabase.GUIDToAssetPath(guid)) as UnityEngine.GameObject;
                if (tGo != null && (tGo.GetComponent<MeshFilter>() != null || tGo.GetComponentInChildren<MeshFilter>() != null || tGo.GetComponentsInChildren<MeshFilter>() != null))
                    tAllMesh.Add(tGo);
            }

            return tAllMesh;
        }



        List<UnityEngine.GameObject> mAllMesh;
        Dictionary<GameObject, int> mDicNoGos = new Dictionary<GameObject, int>();
        private void OnGUI()
        {
            mIsPrefab = EditorGUILayout.Toggle("勾上=Prefab..不勾=Mesh", mIsPrefab);


            if (GUILayout.Button(mIsPrefab ? "   加载   Project面板的Prefab顶点排行" : "   加载   Project面板的Mesh顶点排行", GUILayout.Height(32)))
            {
                mAllMesh = FindOneGos(mIsPrefab ? "Prefab" : "Mesh");
                Debug.Log(mAllMesh.Count);
                mAllMesh.Sort((a, b) =>
                {
                    var aCount = GetMeshVertCount(a);
                    var bCount = GetMeshVertCount(b);
                    if (aCount > bCount)
                        return -1;
                    return 1;
                });
                mDicNoGos = new Dictionary<GameObject, int>();
                for (int i = 0; i < mAllMesh.Count; i++)
                {
                    if (i % 10 == 0)
                    {
                        bool isCancel = EditorUtility.DisplayCancelableProgressBar("计算中", mAllMesh[i].name, (float)i / (float)mAllMesh.Count);
                        if (isCancel)
                        {
                            break;
                        }
                    }

                    if (mDicNoGos.ContainsKey(mAllMesh[i]) == false)
                    {
                        mDicNoGos[mAllMesh[i]] = GetMeshVertCount(mAllMesh[i]);
                    }
                }
                EditorUtility.ClearProgressBar();
                this.ShowNotification(new GUIContent("共计有" + mDicNoGos.Count + "个 含有MeshFilter,已排序"));
            }


            mLookV2 = GUILayout.BeginScrollView(mLookV2);
            if (mAllMesh != null && mAllMesh.Count > 0)
            {
                foreach (var item in mDicNoGos)
                {
                    if (GUILayout.Button(item.Key.name + "   顶点数:" + item.Value))
                    {
                        Selection.activeObject = item.Key;
                    }
                }
            }
            GUILayout.EndScrollView();
        }

        int GetMeshVertCount(GameObject go)
        {
            int aCount = 0;
            //if (go.GetComponent<MeshFilter>() != null)
            //    aCount = aCount + go.GetComponent<MeshFilter>().sharedMesh.vertexCount;
            if (go.GetComponentsInChildren<MeshFilter>() != null)
            {
                var mes = go.GetComponentsInChildren<MeshFilter>();
                for (int i = 0; i < mes.Length; i++)
                {
                    if (mes[i].sharedMesh != null)
                    {
                        aCount = aCount + mes[i].sharedMesh.vertexCount;
                    }
                }
            }
            return aCount;
        }
    }
}
