
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
public partial class TbScript_English
{
    private readonly System.Collections.Generic.Dictionary<int, Script_English> _dataMap;
    private readonly System.Collections.Generic.List<Script_English> _dataList;
    
    public TbScript_English(ByteBuf _buf)
    {
        _dataMap = new System.Collections.Generic.Dictionary<int, Script_English>();
        _dataList = new System.Collections.Generic.List<Script_English>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            Script_English _v;
            _v = Script_English.DeserializeScript_English(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
    }

    public System.Collections.Generic.Dictionary<int, Script_English> DataMap => _dataMap;
    public System.Collections.Generic.List<Script_English> DataList => _dataList;

    public Script_English GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Script_English Get(int key) => _dataMap[key];
    public Script_English this[int key] => _dataMap[key];

    public void ResolveRef(Tables tables)
    {
        foreach(var _v in _dataList)
        {
            _v.ResolveRef(tables);
        }
    }

}

}

