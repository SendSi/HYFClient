
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
public partial class TbShopGiftMenuConfig
{
    private readonly System.Collections.Generic.Dictionary<int, ShopGiftMenuConfig> _dataMap;
    private readonly System.Collections.Generic.List<ShopGiftMenuConfig> _dataList;
    
    public TbShopGiftMenuConfig(ByteBuf _buf)
    {
        _dataMap = new System.Collections.Generic.Dictionary<int, ShopGiftMenuConfig>();
        _dataList = new System.Collections.Generic.List<ShopGiftMenuConfig>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            ShopGiftMenuConfig _v;
            _v = ShopGiftMenuConfig.DeserializeShopGiftMenuConfig(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
    }

    public System.Collections.Generic.Dictionary<int, ShopGiftMenuConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<ShopGiftMenuConfig> DataList => _dataList;

    public ShopGiftMenuConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public ShopGiftMenuConfig Get(int key) => _dataMap[key];
    public ShopGiftMenuConfig this[int key] => _dataMap[key];

    public void ResolveRef(Tables tables)
    {
        foreach(var _v in _dataList)
        {
            _v.ResolveRef(tables);
        }
    }

}

}
