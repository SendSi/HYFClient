
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
public sealed partial class ShopGiftMenuConfig : Luban.BeanBase
{
    public ShopGiftMenuConfig(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        Name = _buf.ReadString();
        RType = _buf.ReadInt();
        ChildViewName = _buf.ReadString();
        IsShow = _buf.ReadInt();
    }

    public static ShopGiftMenuConfig DeserializeShopGiftMenuConfig(ByteBuf _buf)
    {
        return new ShopGiftMenuConfig(_buf);
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
    /// 页面名字
    /// </summary>
    public readonly string ChildViewName;
    /// <summary>
    /// 显示否,1显示
    /// </summary>
    public readonly int IsShow;
   
    public const int __ID__ = -521451641;
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
        + "childViewName:" + ChildViewName + ","
        + "isShow:" + IsShow + ","
        + "}";
    }
}

}

