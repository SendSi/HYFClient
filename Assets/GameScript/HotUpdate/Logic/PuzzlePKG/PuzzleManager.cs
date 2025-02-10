using System.Collections.Generic;
using cfg;
public class PuzzleManager : Singleton<PuzzleManager>
{
    Dictionary<int, List<PuzzleConfig>>
        mPuzzlePlayerDic = new Dictionary<int, List<PuzzleConfig>>(); //key是玩家id,,,,value是手牌

    private List<PuzzleConfig> mPuzzleAllLists;

    public void ListenPuzzle()
    {
    }


    public List<PuzzleConfig> GetSelfCardList(int playerId = 1)
    {
        mPuzzleAllLists =  CfgLubanMgr.Instance.globalTab.TbPuzzleConfig.DataList;//ConfigMgr.Instance.LoadConfigList<PuzzleConfig>();
        mPuzzleAllLists = OtherUtils.Instance.GetRandomList(mPuzzleAllLists); //打乱排序

        for (int i = 1; i < 4; i++)
        {
            mPuzzlePlayerDic[i] = new List<PuzzleConfig>();
        }

        var ply = 1;
        for (int i = 0; i < 52; i++)
        {
            if (ply == 4) ply = 1;
            
            mPuzzlePlayerDic[ply].Add(mPuzzleAllLists[i]);

            ply++;
        }


        return mPuzzlePlayerDic[playerId];
    }
}