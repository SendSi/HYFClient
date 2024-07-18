
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
public partial class TbScript_TraChinese
{
    private readonly System.Collections.Generic.Dictionary<int, Script_TraChinese> _dataMap;
    private readonly System.Collections.Generic.List<Script_TraChinese> _dataList;
    
    public TbScript_TraChinese(ByteBuf _buf)
    {
        _dataMap = new System.Collections.Generic.Dictionary<int, Script_TraChinese>();
        _dataList = new System.Collections.Generic.List<Script_TraChinese>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            Script_TraChinese _v;
            _v = Script_TraChinese.DeserializeScript_TraChinese(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
    }

    public System.Collections.Generic.Dictionary<int, Script_TraChinese> DataMap => _dataMap;
    public System.Collections.Generic.List<Script_TraChinese> DataList => _dataList;

    public Script_TraChinese GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Script_TraChinese Get(int key) => _dataMap[key];
    public Script_TraChinese this[int key] => _dataMap[key];

    public void ResolveRef(Tables tables)
    {
        foreach(var _v in _dataList)
        {
            _v.ResolveRef(tables);
        }
    }

}

}

