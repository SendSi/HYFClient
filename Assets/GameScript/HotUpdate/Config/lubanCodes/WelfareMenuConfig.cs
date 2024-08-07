
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
public sealed partial class WelfareMenuConfig : Luban.BeanBase
{
    public WelfareMenuConfig(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        Name = _buf.ReadString();
        RType = _buf.ReadInt();
        UrlPath = _buf.ReadString();
        IsShow = _buf.ReadInt();
    }

    public static WelfareMenuConfig DeserializeWelfareMenuConfig(ByteBuf _buf)
    {
        return new WelfareMenuConfig(_buf);
    }

    /// <summary>
    /// key
    /// </summary>
    public readonly int Id;
    /// <summary>
    /// 名称
    /// </summary>
    public readonly string Name;
    /// <summary>
    /// 索引id
    /// </summary>
    public readonly int RType;
    /// <summary>
    /// 子类型
    /// </summary>
    public readonly string UrlPath;
    /// <summary>
    /// 显示否,1显示
    /// </summary>
    public readonly int IsShow;
   
    public const int __ID__ = 468149005;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(Tables tables)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "id:" + Id + ","
        + "name:" + Name + ","
        + "rType:" + RType + ","
        + "urlPath:" + UrlPath + ","
        + "isShow:" + IsShow + ","
        + "}";
    }
}

}

