using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemStringUtils : Singleton<ItemStringUtils>
{
    public class Item
    {
        public int Id { get; set; }
        public int Num { get; set; }
    }

    public List<Item> GetListItem(string originalString)
    {
        //  originalString = "12:60;43:600";
        List<Item> itemList = new List<Item>();
        ReadOnlySpan<char> span = originalString.AsSpan();

        int pairStartIndex = 0;
        int pairEndIndex = 0;
        while (pairEndIndex < span.Length)
        {
            pairEndIndex = span.IndexOf(';');

            if (pairEndIndex == -1)
                pairEndIndex = span.Length;

            var pair = span.Slice(pairStartIndex, pairEndIndex - pairStartIndex);
            int colonIndex = pair.IndexOf(':');
            if (colonIndex != -1)
            {
                var idSpan = pair.Slice(0, colonIndex);
                var numSpan = pair.Slice(colonIndex + 1);

                if (int.TryParse(idSpan, out int id) && int.TryParse(numSpan, out int num))
                {
                    itemList.Add(new Item
                    {
                        Id = id,
                        Num = num
                    });
                }
                else
                {
                    Debug.LogError("Failed to parse id or num");
                }
            }
            else
            {
                Debug.LogError("Colon not found in pair: " + pair.ToString());
            }

            pairStartIndex = pairEndIndex + 1;
            span = span.Slice(pairStartIndex);
        }

        return itemList;
    }

    public Item GetOneItem(string originalString)
    {
        ReadOnlySpan<char> span = originalString.AsSpan(); // 解析字符串并返回 Item 对象
        int colonIndex = span.IndexOf(':');
        if (colonIndex != -1)
        {
            var idSpan = span.Slice(0, colonIndex);
            var numSpan = span.Slice(colonIndex + 1);
            if (int.TryParse(idSpan, out int id) && int.TryParse(numSpan, out int num))
            {
                return new Item
                {
                    Id = id,
                    Num = num
                };
            }
            else
            {
                Debug.LogError("Failed to parse id or num");
            }
        }
        else
        {
            Debug.LogError("Colon not found in input: " + originalString);
        }

        return new Item(); // 如果解析失败，则返回默认的 Item 对象
    }
}