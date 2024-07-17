
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;


namespace cfg.item
{
public partial class TbItem
{
    private readonly System.Collections.Generic.Dictionary<int, Item> _dataMap;
    private readonly System.Collections.Generic.List<Item> _dataList;
    
    public TbItem(ByteBuf _buf)
    {
        _dataMap = new System.Collections.Generic.Dictionary<int, Item>();
        _dataList = new System.Collections.Generic.List<Item>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            Item _v;
            _v = Item.DeserializeItem(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
    }

    public System.Collections.Generic.Dictionary<int, Item> DataMap => _dataMap;
    public System.Collections.Generic.List<Item> DataList => _dataList;

    public Item GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Item Get(int key) => _dataMap[key];
    public Item this[int key] => _dataMap[key];

    public void ResolveRef(Tables tables)
    {
        foreach(var _v in _dataList)
        {
            _v.ResolveRef(tables);
        }
    }

}

}

