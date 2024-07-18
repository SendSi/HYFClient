
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
public sealed partial class HeroInfoConfig : Luban.BeanBase
{
    public HeroInfoConfig(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        PathURL = _buf.ReadString();
        Name = _buf.ReadString();
        Desc = _buf.ReadString();
    }

    public static HeroInfoConfig DeserializeHeroInfoConfig(ByteBuf _buf)
    {
        return new HeroInfoConfig(_buf);
    }

    /// <summary>
    /// key值
    /// </summary>
    public readonly int Id;
    /// <summary>
    /// url
    /// </summary>
    public readonly string PathURL;
    /// <summary>
    /// 名字
    /// </summary>
    public readonly string Name;
    /// <summary>
    /// 描述
    /// </summary>
    public readonly string Desc;
   
    public const int __ID__ = -958373558;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(Tables tables)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "id:" + Id + ","
        + "pathURL:" + PathURL + ","
        + "name:" + Name + ","
        + "desc:" + Desc + ","
        + "}";
    }
}

}
