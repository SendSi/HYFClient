using System;
using System.Collections.Generic;
using UnityEngine;

public class RedDotManager : Singleton<RedDotManager>
{
    private Dictionary<RedDotDefine, RedDotTreeNode> mRedDotLogicDic = new Dictionary<RedDotDefine, RedDotTreeNode>();

    public void InitRedDotTree(List<RedDotTreeNode> nodeList)
    {
        foreach (var item in nodeList)
        {
            mRedDotLogicDic.Add(item.node, item);
        }
    }

    public void RegisterRedDotChangeEvent(RedDotDefine redKey, Action<RedDotEnum, bool, int> changeEvent)
    {
        RedDotTreeNode redDotNode = null;
        if (mRedDotLogicDic.TryGetValue(redKey, out redDotNode))
        {
            redDotNode.OnRedDotActiveChange += changeEvent;
        }
        else
        {
            Debug.LogError($"加注 key:{redKey} 不存在  查一下吧");
        }
    }

    public void UnRegisterRedDotChangeEvent(RedDotDefine redKey, Action<RedDotEnum, bool, int> changeEvent)
    {
        RedDotTreeNode redDotNode = null;
        if (mRedDotLogicDic.TryGetValue(redKey, out redDotNode))
        {
            redDotNode.OnRedDotActiveChange -= changeEvent;
            // Debug.LogError($"减注 key:{redKey}  成功");
        }
        else
        {
            Debug.LogError($"减注 key:{redKey} 不存在  查一下吧");
        }
    }

    public void UpdateRedDotState(RedDotDefine redKey)
    {
        if (redKey == RedDotDefine.None)
        {
            return;
        }

        RedDotTreeNode redDotNode = null;
        if (mRedDotLogicDic.TryGetValue(redKey, out redDotNode))
        {

            redDotNode.RefreshRedDotState(); //更新本节点
            UpdateRedDotState(redDotNode.parentNode); //更新 父节点
        }
        else
        {
            Debug.LogError($"UpdateRedDotState key:{redKey} 不存在  查一下吧");
        }
    }

    public int GetChildNodeRedDotCount(RedDotDefine redKey)
    {
        int childCount = 0;
        ComputeChildRedDotCount(redKey, ref childCount);
        return childCount;
    }

    public void ComputeChildRedDotCount(RedDotDefine redKey, ref int childRedDotCount)
    {
        foreach (var item in mRedDotLogicDic.Values)
        {
            if (item.parentNode == redKey)
            {
                item.RefreshRedDotState();
                if (item.redDotActive)
                {
                    childRedDotCount += item.redDotCount;
                    if (item.redDotType != RedDotEnum.DataAdd)
                    {
                        ComputeChildRedDotCount(item.node, ref childRedDotCount);
                    }
                }
            }
        }
    }
}

public enum RedDotEnum
{
    Normal, //仅红点
    NodeNum , //数字红点
    DataAdd , //数字+
}

public enum RedDotDefine
{
    None = 0,

    BagRoot,
    Bag_all, //全部
    Bag_res, //资源
    Bag_equ, //装备
    Bag_other, //其他
}

public class RedDotTreeNode
{
    public RedDotEnum redDotType; //红点类型   默认normal
    public RedDotDefine parentNode; //父节点
    public RedDotDefine node; //当前节点

    public bool redDotActive; //红点显示状态
    public int redDotCount; //显示个数

    public Action<RedDotEnum, bool, int> OnRedDotActiveChange; //红点状态 改变事件
    public Action<RedDotTreeNode> logicHander; //红点逻辑处理

    public virtual bool RefreshRedDotState()
    {
        redDotCount = 0;
        if (redDotType == RedDotEnum.NodeNum)
        {
            //获取子节点 显示的红点个数   去显示红点个数
            redDotCount = RedDotManager.Instance.GetChildNodeRedDotCount(node);
            redDotActive = (redDotCount > 0);
        }
        else
        {
            redDotCount = RefreshRedDotCount();
        }

        logicHander?.Invoke(this);

        if (redDotType == RedDotEnum.DataAdd)
        {
            redDotActive = (redDotCount > 0);
        }
        OnRedDotActiveChange?.Invoke(redDotType, redDotActive, redDotCount);

        return redDotActive;
    }

    public virtual int RefreshRedDotCount()
    {
        return 1;
    }
}