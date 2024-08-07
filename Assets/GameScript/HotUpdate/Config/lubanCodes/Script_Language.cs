
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
public sealed partial class Script_Language : Luban.BeanBase
{
    public Script_Language(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        LangSimChinese = _buf.ReadString();
        LangTraChinese = _buf.ReadString();
        LangEnglish = _buf.ReadString();
    }

    public static Script_Language DeserializeScript_Language(ByteBuf _buf)
    {
        return new Script_Language(_buf);
    }

    /// <summary>
    /// key值
    /// </summary>
    public readonly int Id;
    /// <summary>
    /// 简体中文
    /// </summary>
    public readonly string LangSimChinese;
    /// <summary>
    /// 繁体中文
    /// </summary>
    public readonly string LangTraChinese;
    /// <summary>
    /// 英语
    /// </summary>
    public readonly string LangEnglish;
   
    public const int __ID__ = 1468384332;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(Tables tables)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "id:" + Id + ","
        + "langSimChinese:" + LangSimChinese + ","
        + "langTraChinese:" + LangTraChinese + ","
        + "langEnglish:" + LangEnglish + ","
        + "}";
    }
}

}

