using System.Collections.Generic;
using cfg;

public class PokerManager : Singleton<PokerManager>
{
    Dictionary<int, List<PokerConfig>> mPokerPlayerDic = new Dictionary<int, List<PokerConfig>>(); //key是玩家id,,,,value是手牌
    private List<PokerConfig> mPokerAllLists;

    public void ListenPoker()
    {
    }

    public List<PokerConfig> GetSelfCardList(int playerId = 1)
    {
        mPokerAllLists = CfgLubanMgr.Instance.globalTab.TbPokerConfig.DataList; //ConfigMgr.Instance.LoadConfigList<PokerConfig>();
        mPokerAllLists = OtherUtils.Instance.GetRandomList(mPokerAllLists); //打乱排序

        for (int i = 1; i < 4; i++)
        {
            mPokerPlayerDic[i] = new List<PokerConfig>();
        }

        var ply = 1;
        for (int i = 0; i < 52; i++)
        {
            if (ply == 4) ply = 1;

            mPokerPlayerDic[ply].Add(mPokerAllLists[i]);

            ply++;
        }

        return mPokerPlayerDic[playerId];
    }
}
/// <summary>
/// 斗地主中的各种牌型枚举
/// </summary>
public enum PokerHandType
{
    /// <summary> 单张牌 </summary>
    SingleCard = 1,
    /// <summary> 对子 </summary>
    Pair,
    /// <summary> 三张牌 </summary>
    ThreeOfAKind,
    /// <summary> 三带一对 </summary>
    ThreeWithPair,
    
    /// <summary> 三带两张 </summary>
    ThreeWithTwo,
    /// <summary> 四带两张 </summary>
    FourWithTwo,
    /// <summary> 四带两单 </summary>
    FourWithTwoSingles,
    /// <summary> 四带两对 </summary>
    FourWithTwoPairs,
    /// <summary> 顺子（至少5张连续的单牌） </summary>
    Straight,
    /// <summary> 连对（至少3个连续的对子） </summary>
    StraightPairs,
    /// <summary> 飞机带单牌（至少2个连续的三张牌，带单牌） </summary>
    PlaneWithSingle,
    /// <summary> 飞机带对子（至少2个连续的三张牌，带对子） </summary>
    PlaneWithPair,
    /// <summary> 普通炸弹（四张相同点数的牌） </summary>
    Bomb,
    /// <summary> 王炸（大小王） </summary>
    Rocket,
    /// <summary> 五连顺（5个连续的单牌，J以下） </summary>
    FiveStraight,
    /// <summary> 六连顺（6个连续的单牌，J以下） </summary>
    SixStraight,
    /// <summary> 连三张（至少2组连续的三张牌） </summary>
    ThreeStraight,
    /// <summary> 单顺（至少5张连续的单牌，可以含J、Q、K） </summary>
    SingleStraight,
    /// <summary> 双顺（至少3组连续的对子） </summary>
    DoubleStraight,
    /// <summary> 其他未定义的牌型 </summary>
    Invalid
}




// 单张  对子  三张
//三带一  三带二  顺子 连对  飞机  飞机带翅膀
//四带两单   四带两对
//普炸弹  王炸