public  class BaseInstance<T> where T : BaseInstance<T>,new()
{
    private static T _instance;
    public static T GetInstance()
    {
        if (_instance == null)
        {

            _instance = new T();
            _instance.OnInit();
        }
        return _instance;
    }


    public virtual void OnInit()
    {
    }

}
