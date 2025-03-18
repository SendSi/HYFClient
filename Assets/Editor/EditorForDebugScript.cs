using System.Collections.Generic;
using UnityEngine;

public class EditorForDebugScript
{
    /// <summary>测试  无参数   </summary>
    public void OpenTestNoParam()
    {
        Debug.LogError($"测试 调用了 OpenTestNoParam");
    }

    /// <summary> 测试 传入参数   通用的参数都使用了</summary>
    public void OpenTestToParam(uint pId, string name, bool pBool, int cfgId = 1, float pFloat = 1.1f)
    {
        Debug.LogError($"测试 调用了 OpenTestToParam  传入的  {pId} {name} {pBool} {cfgId} {pFloat}");
    }

    public void SendGM(string str)
    {
        if (string.IsNullOrEmpty(str))
            return;

        if (str.Contains("local"))
        {
            GMManager.Instance.LocalMethodGM(str); //前端自己定义的
        }
        else
        {
            GMManager.Instance.ServerMethodGM(str); //直接发送后端的gm
        }
    }
    //------------------------供 继续写------------

    public void SendTest()
    {
        SceneMapManager.Instance.Test();
    }
}