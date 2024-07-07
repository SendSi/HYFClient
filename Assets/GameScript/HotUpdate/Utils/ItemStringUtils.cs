using System;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int Id { get; set; }
    public int Num { get; set; }

    public Item(int id, int num)
    {
        this.Id = id;
        this.Num = num;
    }
}

public class ItemStringUtils : Singleton<ItemStringUtils>
{
    public List<Item> GetListItem(string originalString)
    {
        List<Item> items = new List<Item>();
        ReadOnlySpan<char> span = originalString.AsSpan();

        ReadOnlySpan<char> numPart;
        ReadOnlySpan<char> idPart;
        while (!span.IsEmpty)
        {
            int colonIndex = span.IndexOf(':');
            int semicolonIndex = span.IndexOf(';');

            idPart = span.Slice(0, colonIndex);

            if (semicolonIndex == -1)
                numPart = span.Slice(colonIndex + 1, span.Length - colonIndex - 1);
            else
                numPart = span.Slice(colonIndex + 1, semicolonIndex - colonIndex - 1);

            if (int.TryParse(idPart, out int id) && int.TryParse(numPart, out int num))
            {
                items.Add(new Item(id, num));
            }

            if (semicolonIndex == -1)
                break;

            span = span.Slice(semicolonIndex + 1);
        }

        return items;
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
                return new Item(id, num);
            }
            else
            {
                Debuger.LogError("Failed to parse id or num");
            }
        }
        else
        {
            Debuger.LogError("Colon not found in input: " + originalString);
        }

        return new Item(1,1); // 如果解析失败，则返回默认的 Item 对象
    }
}