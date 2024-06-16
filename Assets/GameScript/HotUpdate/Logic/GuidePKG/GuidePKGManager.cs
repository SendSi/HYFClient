using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

public class GuidePKGManager : Singleton<GuidePKGManager>
{
    /// <summary> 点击后 是否copy路径  </summary>
    private bool mIsNeedCopyPath = false;
    public void SetIsNeedCopy(string valueStr)
    {
        mIsNeedCopyPath = (valueStr.Equals("1"));
        Debug.LogError($"点击后 是否copy路径:{mIsNeedCopyPath}-->若true则开启,已将会复制路径到剪切板");
    }

    protected override void OnInit()
    {
        base.OnInit();
        Stage.inst.onTouchBegin.Set(OnTouchBegin);
        InitStepConfigs();
    }

    #region 路径复制

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

    #endregion


    #region 执行指引

    Dictionary<int, List<GuideStepConfig>> mGuideStepCfgs = new Dictionary<int, List<GuideStepConfig>>();
    private void InitStepConfigs()
    {
        var tStepCfgs = ConfigMgr.Instance.LoadConfigList<GuideStepConfig>();
        foreach (var stepCfg in tStepCfgs)
        {
            if (mGuideStepCfgs.TryGetValue(stepCfg.gType, out var list))
            {
                list.Add(stepCfg);
            }
            else
            {
                list = new List<GuideStepConfig>() { stepCfg };
                mGuideStepCfgs[stepCfg.gType] = list;
            }
        }
        foreach (var item in mGuideStepCfgs)
        {
            item.Value.Sort((a, b) => a.sortId.CompareTo(b.sortId));//保证顺序
        }
    }

    public void StartGuideStepId(int typeGuide)
    {
        if (mGuideStepCfgs.TryGetValue(typeGuide, out var list))
        {
            ProxyGuidePKGModule.Instance.OpenGuideMainView(list);
        }
    }
    #endregion
    
    
    
}