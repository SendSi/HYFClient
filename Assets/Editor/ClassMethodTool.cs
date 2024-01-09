using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Random = System.Random;
//https://blog.csdn.net/SendSI/article/details/84038522
//使用方法:把使用类放在非Editor使用  使用类也别使用namespace
namespace MEditor
{
    public class ClassMethodTool : EditorWindow
    {
        [MenuItem("Tools/辅助工具/类_方法调用")]
        public static void ShowAsset()
        {
            EditorWindow.GetWindow<ClassMethodTool>(false);
        }

        private string mClassName;
        private string mMethodName;
        private ParameterInfo[] mParamsInfo;
        List<object> mParamsGUI = new List<object>();
        List<string> mParamsNames = new List<string>();

        void ShowLabel(string str)
        {
            this.ShowNotification(new GUIContent(str));
        }

        void TestOne()
        {
            EditorGUILayout.BeginVertical("Box");
            {
                mClassName = EditorGUILayout.TextField("类名:", mClassName);
                mMethodName = EditorGUILayout.TextField("方法名:", mMethodName);
                if (GUILayout.Button("执行", GUILayout.Height(30)))
                {
                    mParamsGUI.Clear();
                    mParamsNames.Clear();
                    if (PlayerPrefs.HasKey(GetType().Name) == false)
                        Debug.Log("此程序集=" + Assembly.GetExecutingAssembly().FullName);
                    PlayerPrefs.SetString(GetType().Name, GetType().Name);
                    if (string.IsNullOrEmpty(mClassName) || string.IsNullOrEmpty(mMethodName)) return;
                    try
                    {
                        var tAsb = Assembly.Load("Assembly-CSharp");
                        var tType = tAsb.GetType(mClassName);
                        var tMethod = tType.GetMethod(mMethodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                        var tObj = Activator.CreateInstance(tType);
                        mParamsInfo = tMethod.GetParameters();
                        if (mParamsInfo.Length == 0)
                        {
                            tMethod.Invoke(tObj, null);
                            ShowLabel("无参数,已调用方法");
                        }
                        for (int i = 0; i < mParamsInfo.Length; i++)
                        {
                            if (tAsb.GetType(mParamsInfo[i].ParameterType.Name) == null)
                            {//基础参数
                                AddParamsGUI(mParamsInfo[i].Name, mParamsInfo[i].ParameterType);
                            }
                            else
                            {//参数是对象类型的
                                var tParamsClass = tAsb.GetType(mParamsInfo[i].ParameterType.Name);
                                var tFields = tParamsClass.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
                                foreach (var item in tFields)
                                {
                                    AddParamsGUI(item.Name, item.FieldType, "-类" + tParamsClass.ToString() + "," + mParamsInfo[i].Name);
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.LogError("异常了--查看类名.方法.参数");
                    }
                }
                if (mParamsInfo != null && mParamsInfo.Length > 0)//参数 展现 填值
                {
                    string s = "";
                    for (int i = 0; i < mParamsNames.Count; i++)//展现
                    {
                        string temp = "";
                        if (mParamsNames[i].Contains("-"))
                        {
                            temp = mParamsNames[i].Split('-')[1];
                            if (s != temp)
                                GUILayout.Label("------" + temp + "--------");
                            ShowParamsGUI(i);
                        }
                        else
                        {
                            temp = UnityEngine.Random.Range(0, 10000).ToString();
                            ShowParamsGUI(i);
                        }
                        s = temp;
                    }
                    if (GUILayout.Button("有参数,得调用参数", GUILayout.Height(27)))//填值
                    {
                        var tAsb = Assembly.Load("Assembly-CSharp");
                        var tType = tAsb.GetType(mClassName);
                        var tMethod = tType.GetMethod(mMethodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                        object tPObj = null;//参数对象实类
                        List<object> tParams = new List<object>();
                        int index = 0;
                        for (int i = 0; i < mParamsInfo.Length; i++)
                        {
                            if (tAsb.GetType(mParamsInfo[i].ParameterType.Name) != null)
                            {
                                var tPObjDto = tAsb.GetType(mParamsInfo[i].ParameterType.Name);
                                tPObj = Activator.CreateInstance(tPObjDto);
                                var tFields = tPObjDto.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
                                for (int j = 0; j < tFields.Length; j++)
                                {
                                    SetFieldValue(tPObj, tFields[j].Name, mParamsGUI[index]);
                                    index++;
                                }
                                tParams.Add(tPObj);
                            }
                            else
                            {
                                index++;
                                tParams.Add(mParamsGUI[i]);
                            }
                        }
                        var tObj = Activator.CreateInstance(tType);
                        if (tPObj == null)
                        {//基础类型.无类参数                      
                            tMethod.Invoke(tObj, mParamsGUI.ToArray());
                        }
                        else
                        {
                            tMethod.Invoke(tObj, tParams.ToArray());
                        }
                        ShowLabel("有参数方法,已调用方法");
                    }
                }
            }
            EditorGUILayout.EndVertical();
        }

        void ShowParamsGUI(int i)
        {
            EditorGUIUtility.labelWidth = 120;
            string label = mParamsNames[i];
            if (mParamsNames[i].Contains("-"))
                label = mParamsNames[i].Split('-')[0];
            if (mParamsGUI[i] is string)
            {
                mParamsGUI[i] = EditorGUILayout.TextField(label, mParamsGUI[i] as string);
            }
            else if (mParamsGUI[i] is int)
            {
                mParamsGUI[i] = EditorGUILayout.IntField(label, int.Parse(mParamsGUI[i].ToString()));
            }
            else if (mParamsGUI[i] is bool)
            {
                mParamsGUI[i] = EditorGUILayout.Toggle(label, bool.Parse(mParamsGUI[i].ToString()));
            }
            else if (mParamsGUI[i] is long)
            {
                mParamsGUI[i] = EditorGUILayout.LongField(label, long.Parse(mParamsGUI[i].ToString()));
            }
        }
        void AddParamsGUI(string pName, Type pT, string className = "")
        {
            if (pT.Name.Equals("String"))
                mParamsGUI.Add("" as string);
            else if (pT.Name.Equals("Int32"))
                mParamsGUI.Add(0);
            else if (pT.Name.Equals("Boolean"))
                mParamsGUI.Add(false);
            else if (pT.Name.Equals("Int64"))
                mParamsGUI.Add(0);
            mParamsNames.Add(pName + "(" + pT.Name + ")" + className);
        }
        /// <summary> 给字段赋值  classObj类对象(已被CreateInstance实例化出来的) </summary>
        void SetFieldValue(object classObj, string pField, object value)
        {
            var tAsb = Assembly.Load("Assembly-CSharp");
            tAsb.GetType(classObj.ToString()).GetField(pField).SetValue(classObj, value);
        }

        void OnGUI()
        {
            TestOne();
            GUILayout.Space(10);
            // TestTwo();
            // GUITestDto();
        }

        //private List<string> mTempName = new List<string>();
        //private List<string> mTempValue = new List<string>();
        //private string mNotifyName;
        //private string mDto;
        //void TestTwo()
        //{
        //    EditorGUILayout.BeginVertical("Box");
        //    {
        //        mNotifyName = EditorGUILayout.TextField("消息名:", mNotifyName);
        //        mDto = EditorGUILayout.TextField("dto:", mDto);
        //        if (GUILayout.Button("执行", GUILayout.Height(30)))
        //        {
        //            try
        //            {
        //                mTempName.Clear(); mTempValue.Clear();
        //                var tAsb = Assembly.Load("Assembly-CSharp");
        //                var tType = tAsb.GetType(mDto);
        //                var tFields = tType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
        //                for (int i = 0; i < tFields.Length; i++)
        //                {
        //                    var tField = tFields[i];
        //                    mTempName.Add(tField.Name);
        //                    mTempValue.Add("");
        //                }
        //                Debug.Log("");
        //            }
        //            catch (Exception e)
        //            {
        //                for (int i = 0; i < mTempName.Count; i++)
        //                {
        //                    mTempValue[i] = EditorGUILayout.TextField(mTempName[i], mTempValue[i]);
        //                }
        //                Debug.LogError("异常了");
        //            }
        //        }

        //        if (mTempValue.Count > 0)
        //        {
        //            for (int i = 0; i < mTempName.Count; i++)
        //            {
        //                mTempValue[i] = EditorGUILayout.TextField(mTempName[i], mTempValue[i]);
        //            }
        //        }
        //    }
        //    EditorGUILayout.EndVertical();
        //}

        ///*         testDto       */
        //private void GUITestDto()
        //{
        //    EditorGUILayout.BeginVertical("Box");
        //    {
        //        if (GUILayout.Button("testDto", GUILayout.Height(27)))
        //        {
        //            var tAsb = Assembly.Load("Assembly-CSharp");
        //            var tParamsClass = tAsb.GetType("TestDto");
        //            var tNewParams = Activator.CreateInstance(tParamsClass);
        //            SetFieldValue(tNewParams, "mId", 1);
        //            SetFieldValue(tNewParams, "mName", "曾哥");
        //            var tFields = tParamsClass.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        //            foreach (var item in tFields)
        //            {
        //                Debug.Log(item.GetValue(tNewParams));
        //            }
        //        }
        //    }
        //    EditorGUILayout.EndVertical();
        //}
    }
}