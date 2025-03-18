using System;
using System.Collections.Generic;
using System.Reflection;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;
using Sirenix.Utilities;
using UnityEngine.Serialization;

[InfoBox("这是一个调用方法的窗口\r\n应用场景:写了一段代码,测试完会还想着之后还要删除,就很烦.(有时还要测时,又得再写一遍,烦)\r\n              现只需在EditorForDebugScript.cs追加代码则可,然后在下拉框选择方法名", InfoMessageType.Info, null)]
public class EditorForDebugWindow : OdinEditorWindow
{
    
    [MenuItem("Tools/辅助工具/方便_调用代码 &#%D", priority = 200)]
    public static void ShowNetTool()
    {
        var win = GetWindow<EditorForDebugWindow>("方便_调用代码");
        win.position = GUIHelper.GetEditorWindowRect().AlignCenter(520, 260);
    }

    /// <summary> 构造函数 </summary>
    private EditorForDebugWindow()
    {
        GetAllMethodsForScripts();
    }

    private Dictionary<string, MethodInfo> mDebugMethod = new Dictionary<string, MethodInfo>();

    [ValueDropdown("mMethodList", IsUniqueList = true)] [LabelText("方法名"), OnValueChanged("ChangeMethodDropdown")]
    public string mMethodName="OpenTestNoParam";

    void ChangeMethodDropdown()
    {
        if (mDebugMethod.TryGetValue(mMethodName, out var method))
        {
            ParameterInfo[] parameterInfos = method.GetParameters();
            var strValue = ""; //若无参数  下面的for 也不会进入 的
            var strName = "";
            for (int i = 0; i < parameterInfos.Length; i++)
            {
                var str = GetDefaultValue(parameterInfos[i].ParameterType);
                strValue += $" {str} ::";
                strName += $"{parameterInfos[i].Name}::";
            }
            mNameParamTxt = $"{mMethodName}::{strValue}".TrimEnd("::".ToCharArray());
            paramNames =$"方法名::参数1::参数2::参数....   使用冒号分隔  {mMethodName}::{strName}".TrimEnd(':');
        }
        else
        {
            mNameParamTxt = mMethodName;
            paramNames =$"方法名::参数1::参数2::参数....    使用冒号分隔 ";
        }
    }

    private List<string> mMethodList = new List<string>();

    [FormerlySerializedAs("mMethodNameTxt")] [LabelText("@ paramNames"), Space(15), TextArea(5, 5)]
    public string mNameParamTxt = "OpenTestNoParam";

    private string paramNames = "方法名::参数1::参数2::参数....            使用冒号分隔  ";//文本提示框

    [Button("调用方法_输入框的", ButtonSizes.Medium, ButtonHeight = 30)]
    public void UsingMethod()
    {
        if (string.IsNullOrEmpty(mNameParamTxt))
        {
            Debug.LogError("上面的方法名与参数 未填入哦");
            return;
        }

        var strList = mNameParamTxt.Split("::");

        if (mDebugMethod.TryGetValue(strList[0], out var method))
        {
            Type type = typeof(EditorForDebugScript);
            var instance = (EditorForDebugScript)Activator.CreateInstance(type);
            var sum = strList.Length;

            ParameterInfo[] parameterInfos = method.GetParameters();
            var parameters2 = new object[parameterInfos.Length]; //若无参数  下面的for 也不会进入 的
            for (int i = 0; i < parameterInfos.Length; i++)
            {
                if (i + 1 < sum)
                {
                    parameters2[i] = Convert.ChangeType(strList[i + 1], parameterInfos[i].ParameterType); // 如果提供了参数值，则使用提供的参数值
                }
                else
                {
                    parameters2[i] = GetDefaultValue(parameterInfos[i].ParameterType); // 如果没有提供参数值，则使用默认值
                }
            }
            method.Invoke(instance, parameters2);
        }
    }

    private object GetDefaultValue(Type type)
    {
        if (type == typeof(string))
        {
            return "str_null";
        }
        else if (type == typeof(float))
        {
            return "0.0";
        }
        else if (type.IsValueType)
        {
            return Activator.CreateInstance(type);
        }
        return null;
    }

    public void GetAllMethodsForScripts()
    {
        Type type = typeof(EditorForDebugScript);
        MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (MethodInfo method in methods)
        {
            if (method.Name == "Equals" || method.Name == "Finalize" || method.Name == "GetHashCode" ||
                method.Name == "GetType" || method.Name == "MemberwiseClone" || method.Name == "ToString")
            {
                //非 手写的 方法
            }
            else
            {
                mDebugMethod[method.Name] = method;
                mMethodList.Add(method.Name);
            }
        }
    }
}