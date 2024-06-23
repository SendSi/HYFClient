using System.Collections.Generic;

public class PokerManager : Singleton<PokerManager>
{
    public void ListenPoker()
    {
    }

    public List<int> GetSelfCardList()
    {
        var list = new List<int>() { 31, 32, 44, 51, 52, 53, 103, 104, 111, 112, 113, 141, 142 }; //假设有这些手牌
        // list.Sort();//++序
        list.Reverse();//--序
        return list;
    }


}
