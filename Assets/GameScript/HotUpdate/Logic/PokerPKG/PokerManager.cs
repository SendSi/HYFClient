using System.Collections.Generic;

public class PokerManager : Singleton<PokerManager>
{
    Dictionary<int, List<PokerConfig>>
        mPokerPlayerDic = new Dictionary<int, List<PokerConfig>>(); //key是玩家id,,,,value是手牌

    private List<PokerConfig> mPokerAllLists;

    public void ListenPoker()
    {
    }


    public List<PokerConfig> GetSelfCardList(int playerId = 1)
    {
        mPokerAllLists = ConfigMgr.Instance.LoadConfigList<PokerConfig>();
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