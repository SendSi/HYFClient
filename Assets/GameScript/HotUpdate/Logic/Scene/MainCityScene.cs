using Cysharp.Threading.Tasks;

public class MainCityScene : SceneBase
{

    public override async UniTask<bool> Init(int mapId,bool backScene)
    {
         base.Init(mapId, backScene).Forget();
         await SceneMapManager.Instance.Init(mapId,backScene);
         return true;
    }

    public override void EnterScene()
    {
        base.EnterScene();
    }

    public override void LeaveScene()
    {
        base.LeaveScene();
    }
}
