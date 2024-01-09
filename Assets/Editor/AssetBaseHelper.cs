using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace MEditor
{

    public class AssetBaseHelper : EditorWindow
    {
        /// <summary> 也就是Inspector面板 的 Apply按钮   并且标记上AB包了</summary>
        public void SaveNewPrefabs(List<GameObject> pWillChanges)
        {
            if (pWillChanges == null || pWillChanges.Count == 0) return;
            for (int i = 0; i < pWillChanges.Count; i++)
            {
                var tPrefab = pWillChanges[i];
                var tOldHierarchyPrefab = PrefabUtility.InstantiatePrefab(tPrefab) as GameObject;
                var tOldUserData = GetUserData(tPrefab);
                var tPath = AssetDatabase.GetAssetPath(tPrefab);
                var tNewEmpty = PrefabUtility.CreateEmptyPrefab(tPath);
                var gameNew = PrefabUtility.ReplacePrefab(tOldHierarchyPrefab, tNewEmpty, ReplacePrefabOptions.ConnectToPrefab);
                GameObject.DestroyImmediate(tOldHierarchyPrefab);
                SaveUserData(gameNew, tOldUserData);
            }
        }

        //生成在Herachchy面板上
        public Transform GenerateHerarchy(GameObject pPrefab, string pPath, bool isUIRoot = true)
        {
            if (pPrefab == null)
                return null;

            GameObject tOldHierarchyPrefab = null;
            if (GameObject.Find(pPrefab.name) == null)
            {
                tOldHierarchyPrefab = PrefabUtility.InstantiatePrefab(pPrefab) as GameObject;
                if (isUIRoot)
                    tOldHierarchyPrefab.transform.parent = GameObject.Find("UI Root").transform;
                tOldHierarchyPrefab.transform.localScale = Vector3.one;
                tOldHierarchyPrefab.transform.localPosition = Vector3.zero;
            }
            else
            {
                tOldHierarchyPrefab = GameObject.Find(pPrefab.name);
            }

            var go = tOldHierarchyPrefab.transform.Find(pPath);
            if (go != null)
            {
                Selection.activeTransform = go;
            }
            return go;
        }


        public string GetUserData(Object obj)
        {
            string pPath = AssetDatabase.GetAssetPath(obj);
            AssetImporter import = AssetImporter.GetAtPath(pPath);
            return import.userData;
        }

        public void SaveUserData(Object pObj, string pData)
        {
            string path = AssetDatabase.GetAssetPath(pObj);
            AssetImporter import = AssetImporter.GetAtPath(path);
            import.userData = pData;
            import.SaveAndReimport();
        }


        /// <summary>根据字符串得到GO           pFilter:Pefab或Script                pGoStr:prefabName </summary>
        public GameObject FindOneGo(string pFilter, string pGoStr)
        {
            var tGuids = AssetDatabase.FindAssets("t:" + pFilter + " " + pGoStr, new string[] { "Assets/Bundles/UI" });
            GameObject tGo = null;
            int i = 0;
            foreach (var guid in tGuids)
            {
                tGo = AssetDatabase.LoadMainAssetAtPath(AssetDatabase.GUIDToAssetPath(guid)) as GameObject;
                i++;
            }
            if (i > 1) Debug.Log("提供的字符串中 搜索出来,有2个+(得到是最后一个)   建议prefab名字加个'_1' 得到字符串后改回来");
            return tGo;
        }

        public List<GameObject> GetPrefabs(string pPath, string pStr = "")
        {
            if (string.IsNullOrEmpty(pPath))
                pPath = "Assets/_Resource/UI/Prefabs";
            var guids = AssetDatabase.FindAssets("t:Prefab " + pStr, new string[] { pPath });
            List<GameObject> tAllPrefab = new List<GameObject>();
            foreach (var item in guids)
            {
                var go = AssetDatabase.LoadMainAssetAtPath(AssetDatabase.GUIDToAssetPath(item)) as GameObject;
                tAllPrefab.Add(go);
            }
            return tAllPrefab;
        }

        /// <summary>
        /// 得到路径
        /// </summary>
        public string FindPath(Transform pParent, Transform pSelect)
        {
            if (pParent == null)
            {
                Debug.LogError("父 路径空了");
                return "";
            }
            if (pSelect == null)
            {
                Debug.LogError("选中 路径空了");
                return "";
            }

            var tStr = "";
            Transform temp = pSelect;
            for (int i = 0; i < 10; i++)//目录一般不会太深
            {
                if (temp.transform == pParent)
                {
                    break;
                }
                else
                {
                    tStr = temp.transform.name + "/" + tStr;
                    temp = temp.transform.parent;
                }
            }
            return (tStr.TrimEnd('/'));//返回路径
        }

        public Dictionary<string, List<string>> GetTextures()
        {
            var pPath = "Assets/_Resource/UI/Texture";

            var guids = AssetDatabase.FindAssets("t:Texture", new string[] { pPath });
            var tAllTexture = new Dictionary<string, List<string>>();
            string tPath;

            foreach (var item in guids)
            {
                tPath = AssetDatabase.GUIDToAssetPath(item);
                if (tPath.Contains("minimap") == false)
                {
                    var tPathDir = tPath.Split('/');
                    var dir1 = tPathDir[4];
                    var dir2 = tPathDir[5].Replace(".png", "");
                    List<string> ttt;
                    if (tAllTexture.TryGetValue(dir1, out ttt))
                    {
                        ttt.Add(dir2);
                        tAllTexture[dir1] = ttt;
                    }
                    else
                    {
                        ttt = new List<string>();
                        ttt.Add(dir2);
                        tAllTexture[dir1] = ttt;
                    }
                }
            }
            return tAllTexture;
        }


        public void ShowSecondDialog(string title, string message, string ok, System.Action okCallBack, string alt = "取消", System.Action altCallBack = null)
        {
            int _buttonID = EditorUtility.DisplayDialogComplex(title, message, ok, alt, "关闭");
            if (okCallBack != null && _buttonID == 0)
            {
                okCallBack();
            }
            else if (altCallBack != null && _buttonID == 1)
            {
                altCallBack();
            }
        }

        public void ShowMsg(string content)
        {
            ShowNotification(new GUIContent(content));
        }

    }
}