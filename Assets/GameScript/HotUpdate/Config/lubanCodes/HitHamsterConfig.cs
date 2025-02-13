
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
public sealed partial class HitHamsterConfig : Luban.BeanBase
{
    public HitHamsterConfig(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        Name = _buf.ReadString();
        Icon = _buf.ReadString();
        EffectDesc = _buf.ReadString();
        ImpactNum = _buf.ReadInt();
        Probability = _buf.ReadInt();
        UseParam = _buf.ReadString();
        NumMax = _buf.ReadInt();
        Img = _buf.ReadString();
        Img2 = _buf.ReadString();
        RefreshTime = _buf.ReadInt();
        Tips = _buf.ReadString();
    }

    public static HitHamsterConfig DeserializeHitHamsterConfig(ByteBuf _buf)
    {
        return new HitHamsterConfig(_buf);
    }

    /// <summary>
    /// key值
    /// </summary>
    public readonly int Id;
    /// <summary>
    /// 物品名称
    /// </summary>
    public readonly string Name;
    public readonly string Icon;
    public readonly string EffectDesc;
    /// <summary>
    /// 打击次数
    /// </summary>
    public readonly int ImpactNum;
    /// <summary>
    /// 对应概率
    /// </summary>
    public readonly int Probability;
    /// <summary>
    /// 效果参数
    /// </summary>
    public readonly string UseParam;
    /// <summary>
    /// 出现次数上限
    /// </summary>
    public readonly int NumMax;
    /// <summary>
    /// 图片
    /// </summary>
    public readonly string Img;
    /// <summary>
    /// 打击后图片
    /// </summary>
    public readonly string Img2;
    /// <summary>
    /// 刷新时间
    /// </summary>
    public readonly int RefreshTime;
    /// <summary>
    /// 提示文本
    /// </summary>
    public readonly string Tips;
   
    public const int __ID__ = -133196655;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(Tables tables)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "id:" + Id + ","
        + "name:" + Name + ","
        + "icon:" + Icon + ","
        + "effectDesc:" + EffectDesc + ","
        + "impactNum:" + ImpactNum + ","
        + "probability:" + Probability + ","
        + "useParam:" + UseParam + ","
        + "numMax:" + NumMax + ","
        + "img:" + Img + ","
        + "img2:" + Img2 + ","
        + "refreshTime:" + RefreshTime + ","
        + "tips:" + Tips + ","
        + "}";
    }
}

}

