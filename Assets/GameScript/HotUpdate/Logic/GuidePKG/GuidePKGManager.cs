using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

public class GuidePKGManager : Singleton<GuidePKGManager>
{
    /// <summary> 点击后 是否copy路径  </summary>
    private bool mIsNeedCopyPath = true;
    public void SetIsNeedCopy(string valueStr)
    {
        mIsNeedCopyPath = (valueStr.Equals("1"));
        Debug.LogError($"点击后 是否copy路径:{mIsNeedCopyPath}-->若true则开启,已将会复制路径到剪切板");
    }

    protected override void OnInit()
    {
        base.OnInit();
        Stage.inst.onTouchBegin.Set(OnTouchBegin);
    }


    private List<string> tmpNames = new List<string>();
    private void OnTouchBegin(EventContext context)
    {
        if (mIsNeedCopyPath == false)
        {
            return;
        }
        var touchTarget = Stage.inst.touchTarget;
        if (touchTarget == null)
        {
            return;
        }
        var target = touchTarget.gOwner;
        if (target != null)
        {
            if (target.GetType() != typeof(GSlider))
            {
                while (target != null && target.onClick.isEmpty &&
                       (target.GetType() != typeof(GButton) ||
                        (target is GButton && target.asButton.relatedController == null)))
                {
                    target = target.parent;
                }

                while (target != null && target != GRoot.inst)
                {
                    tmpNames.Insert(0, target.name);
                    target = target.parent;
                }
            }
        }

        if (tmpNames.Count > 0)
        {
            var result = $"path:{string.Join(".", tmpNames)}";
            tmpNames.Clear();
            UnityEngine.GUIUtility.systemCopyBuffer = result;
            Debug.LogWarning(result);
        }
        else
        {
            Debug.LogWarning("结果: 非button 不去copy");
        }
    }
}