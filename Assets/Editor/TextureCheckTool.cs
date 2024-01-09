using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MEditor
{
    public class TextureEditor : AssetBaseHelper
    {
        [MenuItem("Tools/辅助工具/贴图检测")]
        public static void ShowTexture()
        {
            EditorWindow.GetWindow(typeof(TextureEditor), false, "贴图");
        }


        GUIStyle redStyle = new GUIStyle();
        GUIStyle greenStyle = new GUIStyle();
        GUIStyle lblBtnStyle;
        void LoadStyle()
        {
            redStyle.fontSize = 14;
            redStyle.normal.textColor = new Color(1, 0, 0);

            greenStyle.fontSize = 14;
            greenStyle.normal.textColor = new Color(0, 1, 0);

            lblBtnStyle = new GUIStyle(GUI.skin.label);
            lblBtnStyle.fontSize = 12;
            lblBtnStyle.normal.textColor = new Color(1, 1, 0);
        }

        private string mSearchPath = @"Assets\GameArt";
        private int mSelectTexType;
        private string[] mTextureTypes = { "后缀不计:则all", "*.png", "*.jpg" };
        Dictionary<int, string> mTextureTypeDic = new Dictionary<int, string>() { { 0, ".*" }, { 1, ".png" }, { 2, ".jpg" }, };
        Vector2 mScrollViewShow;
        List<Texture> mFindResultGos;
        private string[] mReadWriteEnables = { "Read_Write Enable不计", "Read_Write Enable=true可读写(启用中)", "Read_Write Enable=false不可读写(禁用中)" };
        private int mSelectReadWrite;

        private string[] mGenerateMipMaps = { "Generate Mip Maps不计", "Generate Mip Maps=true(启用中)", "Generate Mip Maps=false(禁用中)" };
        private int mSelectGenerateMip;


        List<Texture> mSVTextures = new List<Texture>();

        private void OnGUI()
        {
            EditorGUILayout.LabelField("图片的Read/Write Enable属性,一般情况下都要为false; 而启用(可读写)后纹理的内存消耗会增加一倍");
            EditorGUILayout.LabelField("Generate Mip Maps：如果不是3D模型贴图，则禁用，否则会多出约33 % 的内存开销;UI完全用不到的");
            using (new GUILayout.HorizontalScope())
            {
                mSearchPath = EditorGUILayout.TextField("路径", mSearchPath);
                mSearchPath = mSearchPath.Trim();
                mSelectTexType = EditorGUILayout.Popup(mSelectTexType, mTextureTypes, GUILayout.Height(20), GUILayout.MaxWidth(150));
                if (GUILayout.Button("查找", GUILayout.MaxWidth(80)))
                {
                    if (string.IsNullOrEmpty(mSearchPath))
                    {
                        mSearchPath = "Assets";
                        ShowMsg("定位到Assets目录上了");
                    }
                    if (mSearchPath.Contains("Assets") == false)
                    {
                        mSearchPath = "Assets";
                        ShowMsg("定位到Assets目录上了");
                    }
                    if (mSearchPath.EndsWith("/"))
                    {
                        mSearchPath = mSearchPath.Remove(mSearchPath.Length - 1, 1);
                    }
                    GUI.FocusControl("");//使 输入框失去焦点
                    LoadStyle();
                    mFindResultGos = FindTypeGos(mSelectTexType, "Texture", mSearchPath);
                }
            }

            if (mFindResultGos != null && mFindResultGos.Count > 0)
            {
                using (new GUILayout.HorizontalScope())
                {
                    EditorGUILayout.LabelField("共计" + mFindResultGos.Count.ToString() + "张图片", GUILayout.Height(20), GUILayout.MinWidth(200));
                    mSelectReadWrite = EditorGUILayout.Popup(mSelectReadWrite, mReadWriteEnables, GUILayout.Height(20));
                    mSelectGenerateMip = EditorGUILayout.Popup(mSelectGenerateMip, mGenerateMipMaps, GUILayout.Height(20));
                }
                mScrollViewShow = GUILayout.BeginScrollView(mScrollViewShow);
                mSVTextures.Clear();
                int countSV = 0;
                bool isMipMaps = false;
                bool isReadable = false;
                for (int i = 0; i < mFindResultGos.Count; i++)
                {
                    if (mFindResultGos[i] == null || mFindResultGos[i].name == null)
                    {
                        continue;
                    }
                    isMipMaps = GetMipMapEnabled(mFindResultGos[i]);
                    isReadable = mFindResultGos[i].isReadable;
                    if ((mSelectReadWrite == 0 && mSelectGenerateMip == 0)
                        || (mSelectReadWrite == 0 && mSelectGenerateMip == 1 && isMipMaps)
                        || (mSelectReadWrite == 0 && mSelectGenerateMip == 2 && isMipMaps == false)
                        || (mSelectReadWrite == 1 && isReadable && mSelectGenerateMip == 0)
                        || (mSelectReadWrite == 1 && isReadable && mSelectGenerateMip == 1 && isMipMaps)
                        || (mSelectReadWrite == 1 && isReadable && mSelectGenerateMip == 2 && isMipMaps == false)
                        || (mSelectReadWrite == 2 && isReadable == false && mSelectGenerateMip == 0)
                        || (mSelectReadWrite == 2 && isReadable == false && mSelectGenerateMip == 1 && isMipMaps)
                        || (mSelectReadWrite == 2 && isReadable == false && mSelectGenerateMip == 2 && isMipMaps == false))
                    {
                        mSVTextures.Add(mFindResultGos[i]);
                        countSV = countSV + 1;
                        using (new GUILayout.HorizontalScope())
                        {
                            if (GUILayout.Button(mFindResultGos[i].name, lblBtnStyle, GUILayout.Width(120)))
                            {
                                EditorGUIUtility.PingObject(mFindResultGos[i]);
                            }
                            GUILayout.Label(mFindResultGos[i], GUILayout.Height(20), GUILayout.Width(120));//缩略图
                            GUILayout.Label(isReadable ? "RW启用中" : "RW禁用中", isReadable ? redStyle : greenStyle, GUILayout.Width(65));
                            if (GUILayout.Button(isReadable ? "改为不读写" : "改为可读写", GUILayout.Height(20), GUILayout.Width(75)))
                            {
                                SetTextureReadWrite(mFindResultGos[i], !isReadable);//非
                            }

                            GUILayout.Label(isMipMaps ? "  MipMaps启用中" : "  MipMaps禁用中", isMipMaps ? redStyle : greenStyle, GUILayout.Width(105));
                            if (GUILayout.Button(isMipMaps ? "MipMaps改为false" : "MipMaps改为true", GUILayout.Height(20), GUILayout.Width(110)))
                            {
                                SetMipMapEnabled(mFindResultGos[i], !isMipMaps);//非
                            }
                        }
                    }
                }
                GUILayout.EndScrollView();

                GUILayout.BeginHorizontal("Box");
                EditorGUILayout.LabelField("列表" + countSV.ToString() + "张图片", lblBtnStyle, GUILayout.MinWidth(200));
                if (mSelectReadWrite >= 1)
                    if (GUILayout.Button(mSelectReadWrite == 1 ? "RW全改为禁用" : "RW全改为启用:慎呀", GUILayout.Height(19)))
                    {
                        for (int i = 0; i < mSVTextures.Count; i++)
                        {
                            SetTextureReadWrite(mSVTextures[i], mSelectReadWrite == 2);
                        }
                    }
                if (mSelectGenerateMip >= 1)
                    if (GUILayout.Button(mSelectGenerateMip == 1 ? "Mip全改为禁用" : "Mip全改为启用:慎呀", GUILayout.Height(19)))
                    {
                        if (mSelectGenerateMip == 2)
                        {
                            ShowSecondDialog("提示", "是否改成全启用?", "确定", delegate
                            {
                                for (int i = 0; i < mSVTextures.Count; i++)
                                {
                                    SetMipMapEnabled(mSVTextures[i], true);
                                }
                            });
                        }
                        else
                        {
                            for (int i = 0; i < mSVTextures.Count; i++)
                            {
                                SetMipMapEnabled(mSVTextures[i], false);
                            }
                        }
                    }
                GUILayout.EndHorizontal();
            }
        }


        void SetTextureReadWrite(Texture pTex, bool isRead)
        {
            var tex = (TextureImporter)TextureImporter.GetAtPath(AssetDatabase.GetAssetPath(pTex));
            if (tex != null)
            {
                tex.isReadable = isRead;
                AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(pTex));
            }
        }
        bool GetMipMapEnabled(Texture pTex)
        {
            var tex = (TextureImporter)TextureImporter.GetAtPath(AssetDatabase.GetAssetPath(pTex));
            if (tex != null)
                return tex.mipmapEnabled;

            return false;
        }

        void SetMipMapEnabled(Texture pTex, bool mipMapEnabled)
        {
            var tex = (TextureImporter)TextureImporter.GetAtPath(AssetDatabase.GetAssetPath(pTex));
            if (tex != null)
            {
                tex.mipmapEnabled = mipMapEnabled;
                AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(pTex));
            }
        }

        public List<Texture> FindTypeGos(int pType, string pFilter = "Texture", string pSearchPath = "Assets")
        {
            var tGuids = AssetDatabase.FindAssets("t:" + pFilter, new string[] { pSearchPath });
            Texture tGo = null;
            string path = string.Empty;
            List<Texture> tGos = new List<Texture>();
            int i = 0;
            foreach (var guid in tGuids)
            {
                path = AssetDatabase.GUIDToAssetPath(guid);
                if (System.IO.Path.GetExtension(path) == ".asset" ||
                    System.IO.Path.GetExtension(path) == ".ttf" ||
                    System.IO.Path.GetExtension(path) == ".otf")//texture的映射
                {
                    continue;
                }

                tGo = AssetDatabase.LoadMainAssetAtPath(path) as Texture;
                if (tGo == null)
                {
                    Debug.LogWarning("path=" + path);
                }

                if (pType == 0)
                    tGos.Add(tGo);
                else if (System.IO.Path.GetExtension(path) == mTextureTypeDic[pType])
                    tGos.Add(tGo);
                i++;
            }
            return tGos;
        }

        public void ShowMsg(string content)
        {
            ShowNotification(new GUIContent(content));
        }

    }
}