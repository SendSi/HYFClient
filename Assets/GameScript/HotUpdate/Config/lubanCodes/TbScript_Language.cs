
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
public partial class TbScript_Language
{
    private readonly System.Collections.Generic.Dictionary<int, Script_Language> _dataMap;
    private readonly System.Collections.Generic.List<Script_Language> _dataList;
    
    public TbScript_Language(ByteBuf _buf)
    {
        _dataMap = new System.Collections.Generic.Dictionary<int, Script_Language>();
        _dataList = new System.Collections.Generic.List<Script_Language>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            Script_Language _v;
            _v = Script_Language.DeserializeScript_Language(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
    }

    public System.Collections.Generic.Dictionary<int, Script_Language> DataMap => _dataMap;
    public System.Collections.Generic.List<Script_Language> DataList => _dataList;

    public Script_Language GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Script_Language Get(int key) => _dataMap[key];
    public Script_Language this[int key] => _dataMap[key];

    public void ResolveRef(Tables tables)
    {
        foreach(var _v in _dataList)
        {
            _v.ResolveRef(tables);
        }
    }

}

}

