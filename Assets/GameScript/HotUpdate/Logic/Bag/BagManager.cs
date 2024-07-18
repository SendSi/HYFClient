﻿using System.Collections.Generic;

public class BagManager : Singleton<BagManager>
{
    public void ListenBag()
    {
        var bagFatherRoot = new RedDotTreeNode { node = RedDotDefine.BagRoot, logicHander = OnBagRootRedDotLogicHandler };
        var bag_All_Node = new RedDotTreeNode { parentNode = RedDotDefine.BagRoot, node = RedDotDefine.Bag_all, logicHander = OnBagAllRedDotLogicHandler };
        var bag_Res_Node = new RedDotTreeNode { parentNode = RedDotDefine.BagRoot, node = RedDotDefine.Bag_res, logicHander = OnBagResRedDotLogicHandler };
        var bag_Equ_Node = new RedDotTreeNode { parentNode = RedDotDefine.BagRoot, node = RedDotDefine.Bag_equ, logicHander = OnBagEquRedDotLogicHandler };
        RedDotManager.Instance.InitRedDotTree(new List<RedDotTreeNode> { bagFatherRoot, bag_All_Node, bag_Res_Node, bag_Equ_Node });
        Debuger.LogWarning("BagManager ListenBag");
    }

    private void OnBagResRedDotLogicHandler(RedDotTreeNode redNode)
    {
        redNode.redDotActive = GetResRedDot();
        Debuger.Log("OnBagResRedDotLogicHandler:" + redNode.redDotActive);
    }

    private void OnBagRootRedDotLogicHandler(RedDotTreeNode redNode)
    {
        redNode.redDotActive = GetRootRedDot();
        Debuger.Log("OnBagRootRedDotLogicHandler:" + redNode.redDotActive);
    }

    private void OnBagAllRedDotLogicHandler(RedDotTreeNode redNode)
    {
        redNode.redDotActive = GetAllRedDot();
        Debuger.Log("OnBagAllRedDotLogicHandler:" + redNode.redDotActive);
    }

    private void OnBagEquRedDotLogicHandler(RedDotTreeNode redNode)
    {
        redNode.redDotActive = GetEquRedDot();
        Debuger.Log("OnBagEquRedDotLogicHandler:" + redNode.redDotActive);
    }

    private List<ItemDto> mServerDtos = new List<ItemDto>();

    public int GetServerItemSum(int cfgId)
    {
        var sumT = 0;
        foreach (var item in mServerDtos)
        {
            if (item.CfgId == cfgId)
            {
                sumT += item.Sum;
            }
        }

        return sumT;
    }

    public List<ItemDto> GetBagViewListItem()
    {
        var sortDtos = new List<ItemDto>();
        foreach (var item in mServerDtos)
        {
            var cfg = CfgLubanMgr.Instance.globalTab.TbItemConfig.Get(item.CfgId); //ConfigMgr.Instance.LoadConfigOne<ItemConfig>(item.CfgId.ToString());
            if (cfg != null && cfg.Type > 1)
            {
                sortDtos.Add(item);
            }
        }

        return sortDtos;
    }

 

    private bool all = true;
    private bool res = true;
    private bool equ = true;

    public bool GetRootRedDot()
    {
        return all || equ || res;
    }

    private bool GetAllRedDot()
    {
        return all;
    }

    private bool GetResRedDot()
    {
        return res;
    }

    private bool GetEquRedDot()
    {
        return equ;
    }

    public void BagTabReadIndex(int sIndex)
    {
        if (sIndex == 0)
        {
            all = false;
            RedDotManager.Instance.UpdateRedDotState(RedDotDefine.Bag_all);
        }
        else if (sIndex == 1)
        {
            res = false;
            RedDotManager.Instance.UpdateRedDotState(RedDotDefine.Bag_res);
        }
        else if (sIndex == 2)
        {
            equ = false;
            RedDotManager.Instance.UpdateRedDotState(RedDotDefine.Bag_equ);
        }
    }
}

public class ItemDto
{
    public int CfgId;
    public int Sum;
    public string uid;

    public ItemDto(int cfgId, int sum, string uid)
    {
        this.CfgId = cfgId;
        this.Sum = sum;
        this.uid = uid;
    }
}