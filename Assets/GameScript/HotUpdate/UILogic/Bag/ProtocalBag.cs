using HYFServer;
using UnityEngine;

public class ProtocalBag : Singleton<ProtocalBag>
{
    private BagService.BagServiceClient mService;

    protected override void OnInit()
    {
        base.OnInit();
        mService = new BagService.BagServiceClient(GrpcChannelManager.Instance.MainChannel);
        EventCenter.Instance.Bind<PushRsp>(EventEnum.EE_Server_Items,OnEventServicePush);
        Debug.LogError("oninit");
    }

    private void OnEventServicePush(PushRsp rsp)
    {
        switch (rsp.PushMessageCase)
        {
            case PushRsp.PushMessageOneofCase.ItemDots:
                Debug.LogError("???");
                BagManager.Instance.SetServerItems(rsp.ItemDots);
                break;
        }
    }

    public void TT()
    {
        
    }


        

}