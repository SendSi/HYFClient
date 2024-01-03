using System.Collections.Generic;

public class BagManager : BaseInstance<BagManager>
{
    //假设服务器下发的这些数据
    private List<ItemDto> mServerDtos = new List<ItemDto>()
    {
        new ItemDto(1, 2, "ab6c"),
        new ItemDto(2, 22, "abc"),
        new ItemDto(3, 32, "a6bc"),
        new ItemDto(5, 99, "a6gsdbc"),
        new ItemDto(5, 32, "a6bc"),
        new ItemDto(58, 32, "a6bc"),
        new ItemDto(59, 32, "a6bc"),
        new ItemDto(2401, 72, "abc"),
        new ItemDto(2434, 72, "abc"),
        new ItemDto(2435, 702, "abc"),
        new ItemDto(10001, 12, "a6bc"),
        new ItemDto(40001, 2, "abc"),
        new ItemDto(30001, 62, "abc"),
        new ItemDto(10001, 12, "a6bc"),
    };

    public int GetServerItemSum(int cfgId)
    {
        var sumT = 0;
        foreach (var item in mServerDtos)
        {
            if (item.cfgId==cfgId)
            {
                sumT += item.sum;
            }
        }

        return sumT;
    }

    public List<ItemDto> GetBagViewListItem()
    {
        List<ItemDto> sortItem = new List<ItemDto>();
        foreach (var item in mServerDtos)
        {
            var cfg = ConfigMgr.GetInstance().LoadConfigOne<ItemConfig>(item.cfgId.ToString());
            if (cfg != null && cfg.type > 1)
            {
                sortItem.Add(item);
            }
        }

        return sortItem;
    }
}


public class ItemDto
{
    public int cfgId;
    public int sum;
    public string uid;

    public ItemDto(int cfgId, int sum, string uid)
    {
        this.cfgId = cfgId;
        this.sum = sum;
        this.uid = uid;
    }
}