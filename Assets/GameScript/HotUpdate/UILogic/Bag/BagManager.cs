using System.Collections.Generic;
using HYFServer;
using UnityEngine;

public class BagManager : Singleton<BagManager>
{
    //假设服务器下发的这些数据
    // private List<ItemDto> mServerDtos = new List<ItemDto>()
    // {
    // new ItemDto(1, 2, "ab6c"),new ItemDto(2, 22, "abc"),new ItemDto(3, 32, "a6bc"),new ItemDto(5, 99, "a6gsdbc"),new ItemDto(5, 32, "a6bc"),new ItemDto(58, 32, "a6bc"),
    // new ItemDto(59, 32, "a6bc"),new ItemDto(2401, 72, "abc"),new ItemDto(2434, 72, "abc"),new ItemDto(2435, 702, "abc"),new ItemDto(10001, 12, "a6bc"),new ItemDto(40001, 2, "abc"),
    // new ItemDto(30001, 62, "abc"),new ItemDto(10001, 12, "a6bc"),
    // };
    
    private List<ItemDto> mServerDtos = new List<ItemDto>();

    public int GetServerItemSum(int cfgId)
    {
        var sumT = 0;
        foreach (var item in mServerDtos)
        {
            if (item.CfgId==cfgId)
            {
                sumT += item.Sum;
            }
        }

        return sumT;
    }

    public List<ItemDto> GetBagViewListItem()
    {
        var sortDtos = new List<ItemDto>();
        Debug.LogError(mServerDtos.Count);
        foreach (var item in mServerDtos)
        {
            var cfg = ConfigMgr.Instance.LoadConfigOne<ItemConfig>(item.CfgId.ToString());
            if (cfg != null && cfg.type > 1)
            {
                sortDtos.Add(item);
            }
            
        }

        return sortDtos;
    }

    public void SetServerItems(ItemDtos rspItemDots)
    {
        for (int i = 0; i < rspItemDots.ItemInfos.Count; i++)
        {
            mServerDtos.Add(rspItemDots.ItemInfos[i]);
        }
    }
}

