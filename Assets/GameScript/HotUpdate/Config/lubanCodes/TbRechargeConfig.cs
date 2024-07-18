
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
public partial class TbRechargeConfig
{
    private readonly System.Collections.Generic.Dictionary<int, RechargeConfig> _dataMap;
    private readonly System.Collections.Generic.List<RechargeConfig> _dataList;
    
    public TbRechargeConfig(ByteBuf _buf)
    {
        _dataMap = new System.Collections.Generic.Dictionary<int, RechargeConfig>();
        _dataList = new System.Collections.Generic.List<RechargeConfig>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            RechargeConfig _v;
            _v = RechargeConfig.DeserializeRechargeConfig(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
    }

    public System.Collections.Generic.Dictionary<int, RechargeConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<RechargeConfig> DataList => _dataList;

    public RechargeConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public RechargeConfig Get(int key) => _dataMap[key];
    public RechargeConfig this[int key] => _dataMap[key];

    public void ResolveRef(Tables tables)
    {
        foreach(var _v in _dataList)
        {
            _v.ResolveRef(tables);
        }
    }

}

}

