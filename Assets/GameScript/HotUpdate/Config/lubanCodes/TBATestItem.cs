
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;


namespace cfg
{
public partial class TBATestItem
{
    private readonly System.Collections.Generic.Dictionary<int, ATestItem> _dataMap;
    private readonly System.Collections.Generic.List<ATestItem> _dataList;
    
    public TBATestItem(ByteBuf _buf)
    {
        _dataMap = new System.Collections.Generic.Dictionary<int, ATestItem>();
        _dataList = new System.Collections.Generic.List<ATestItem>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            ATestItem _v;
            _v = ATestItem.DeserializeATestItem(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
    }

    public System.Collections.Generic.Dictionary<int, ATestItem> DataMap => _dataMap;
    public System.Collections.Generic.List<ATestItem> DataList => _dataList;

    public ATestItem GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public ATestItem Get(int key) => _dataMap[key];
    public ATestItem this[int key] => _dataMap[key];

    public void ResolveRef(Tables tables)
    {
        foreach(var _v in _dataList)
        {
            _v.ResolveRef(tables);
        }
    }

}

}

