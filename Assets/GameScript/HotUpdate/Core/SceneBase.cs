using Cysharp.Threading.Tasks;

public class SceneBase
{
    public bool IsInScene = false;

    public virtual async UniTask<bool> Init(int mapId, bool backScene)
    {
        IsInScene = true;
        return true;
    }

    public virtual void EnterScene()
    {
        
    }

    protected virtual void AddEvent()
    {
        
    }
    protected virtual void RemoveEvent()
    {
        
    }

    public virtual void LeaveScene()
    {
        RemoveEvent();
        IsInScene=false;
    }

}
