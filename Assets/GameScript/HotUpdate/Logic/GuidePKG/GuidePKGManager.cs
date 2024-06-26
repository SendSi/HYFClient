#region << 脚 本 注 释 >>
//作   用:    游戏指引步骤 调用StartGuideStepId(),导表看GuideTypeConfig.xlsx等文件  fgui包=GuidePKG  copy路径功能请使用GM命令
//作   者:    曾思信
//创建时间:  #CREATETIME#
#endregion

using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

public class GuidePKGManager : Singleton<GuidePKGManager>
{
    /// <summary> 点击后 是否copy路径  </summary>
    private bool mIsNeedCopyPath = false;

    /// <summary> 是否在执行 指引中  </summary>
    private bool mIsGuideing = false;

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
        EventCenter.Instance.Bind(EventEnum.EE_Guide_NextStep, OnEventGuideNextStep);
    }

    #region 点击识别路径
    private List<string> tmpNames;

    private void OnTouchBegin(EventContext context)
    {
        if (mIsNeedCopyPath)
        {
            tmpNames = new List<string>();
            var result = GetTempNames();
            if (string.IsNullOrEmpty(result) == false)
            {
                UnityEngine.GUIUtility.systemCopyBuffer = result;
                Debug.LogWarning(result);
            }
        }

        if (mIsGuideing && mCurrStepCfg != null)
        {
            if (string.IsNullOrEmpty(mCurrStepCfg.uiPath))
            {
                EventCenter.Instance.Fire<string>(EventEnum.EE_Guide_UIPath, "true");
            }
            else
            {
                tmpNames = new List<string>();
                var result = GetTempNames();
                if (string.IsNullOrEmpty(result) == false)
                {
                    EventCenter.Instance.Fire<string>(EventEnum.EE_Guide_UIPath, result);
                }
            }
        }
    }

    string GetTempNames()
    {
        var touchTarget = Stage.inst.touchTarget;
        if (touchTarget == null) return null;
        var target = touchTarget.gOwner;
        if (target != null)
        {
            if (target.GetType() != typeof(GSlider))
            {
                while (target != null && target.onClick.isEmpty && (target.GetType() != typeof(GButton) || (target is GButton && target.asButton.relatedController == null)))
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
            return result;
        }

        return null;
    }
    #endregion

    #region 执行指引
    Queue<GuideStepConfig> mCurrentSteps = new Queue<GuideStepConfig>(); //当前执行的执行步骤    当前的余下的步骤
    GuideStepConfig mCurrStepCfg; //当前执行的步骤配置  具体的某一步
    Dictionary<int, List<GuideStepConfig>> mGuideStepCfgs = new Dictionary<int, List<GuideStepConfig>>(); //初始存储配置

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
            item.Value.Sort((a, b) => a.sortId.CompareTo(b.sortId)); //保证顺序
        }
    }

    public void StartGuideStepId(int typeGuide)
    {
        if (mGuideStepCfgs.TryGetValue(typeGuide, out var list))
        {
            Debug.LogWarning("收到指令，开始指引了");
            mCurrentSteps.Clear();
            foreach (var item in list)
            {
                mCurrentSteps.Enqueue(item);
            }

            mIsGuideing = true;
            mCurrStepCfg = mCurrentSteps.Dequeue();
            ProxyGuidePKGModule.Instance.OpenGuideMainView(mCurrStepCfg);
        }
    }

    void OnEventGuideNextStep()
    {
        if (mIsGuideing && mCurrentSteps != null && mCurrentSteps.Count > 0)
        {
            mCurrStepCfg = mCurrentSteps.Dequeue();
            ProxyGuidePKGModule.Instance.OpenGuideMainView(mCurrStepCfg);
        }
        else
        {
            mIsGuideing = false;
            ProxyGuidePKGModule.Instance.HideGuideMainView();
            Debug.LogWarning("完成指引了");
        }
    }

    public void StopGuide()
    {
        mCurrStepCfg = null;
        mCurrentSteps.Clear();
        mIsGuideing = false;
        ProxyGuidePKGModule.Instance.HideGuideMainView();
    }
    #endregion

    protected override void OnDispose()
    {
        base.OnDispose();
        EventCenter.Instance.UnBind(EventEnum.EE_Guide_NextStep, OnEventGuideNextStep);
    }
}