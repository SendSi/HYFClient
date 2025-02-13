public class HitHamsterPKGManager : Singleton<HitHamsterPKGManager>
{
    private int mSumTime = 300; //总时间 30秒
    private int mHp = 5;
    private int mScore = 0;
    protected override void OnInit()
    {
        base.OnInit();
        mSumTime = 300; //总时间 30秒
        mHp = 5;
        mScore = 0;
    }

    public void AddTime(int oneTime)
    {
        mSumTime += oneTime;
    }

    public int GetSumTime()
    {
        return mSumTime;
    }

    public void AddHp(int oneHp)
    {
        mHp += oneHp;
    }

    public int GetHp()
    {
        return mHp;
    }

    public void AddScore(int oneScore)
    {
        mScore += oneScore;
    }

    public int GetScore()
    {
        return mScore;
    }

    protected override void OnDispose()
    {
        base.OnDispose();
        mSumTime = 300; //总时间 30秒
        mHp = 5;
        mScore = 0;
    }
    
    
}