
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
public sealed partial class EightGiftConfig : Luban.BeanBase
{
    public EightGiftConfig(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        Name = _buf.ReadString();
        Reward = _buf.ReadString();
    }

    public static EightGiftConfig DeserializeEightGiftConfig(ByteBuf _buf)
    {
        return new EightGiftConfig(_buf);
    }

    /// <summary>
    /// key值
    /// </summary>
    public readonly int Id;
    /// <summary>
    /// 道具名称
    /// </summary>
    public readonly string Name;
    /// <summary>
    /// 获得道具
    /// </summary>
    public readonly string Reward;
   
    public const int __ID__ = -809618847;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(Tables tables)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "id:" + Id + ","
        + "name:" + Name + ","
        + "reward:" + Reward + ","
        + "}";
    }
}

}
