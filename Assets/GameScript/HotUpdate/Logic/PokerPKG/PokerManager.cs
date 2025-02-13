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
// 单张  对子  三张
//三带一  三带二  顺子 连对  飞机  飞机带翅膀
//四带两单   四带两对
//普炸弹  王炸