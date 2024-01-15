public  class Singleton<T> where T : Singleton<T>,new()
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new T();
                _instance.OnInit();
            }
            return _instance;
        }
    }


    protected virtual void OnDispose()
    {
        
    }
    protected virtual void OnInit()
    {
    }

    public void Dispose()
    {
        OnDispose();
    }

    //写上空方法 为了调用 OnInit
    public void Begin()
    {

    }

}