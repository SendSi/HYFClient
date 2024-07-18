using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/// <summary>
/// 用来格式化 数据的
/// </summary>
public class FormatUtils : Singleton<FormatUtils>
{
    Dictionary<string, List<ItemFormat>> mFormatItemDic = new Dictionary<string, List<ItemFormat>>();


    public List<ItemFormat> GetFormatItem(string itemStr)
    {
        if (mFormatItemDic.TryGetValue(itemStr, out var itemList))
        {
            return itemList;
        }
        else
        {
            itemList = new List<ItemFormat>();
            var matches = Regex.Matches(itemStr, @"(\d+):(\d+)");

            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    var id = int.Parse(match.Groups[1].Value);
                    var num = int.Parse(match.Groups[2].Value);
                    itemList.Add(new ItemFormat(id, num));
                }
            }

            mFormatItemDic[itemStr] = itemList;
            return itemList;
        }
    }
}

public class ItemFormat
{
    public int id { get; set; }
    public int num { get; set; }

    public ItemFormat(int id, int num)
    {
        this.id = id;
        this.num = num;
    }
}