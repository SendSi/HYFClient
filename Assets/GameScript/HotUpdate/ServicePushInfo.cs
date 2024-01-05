using System.Threading;
using HYFServer;
using UnityEngine;

// public class ServicePushInfo : MonoBehaviour
public class ServicePushInfo : Singleton<ServicePushInfo>
{
    public void Start()
    {
        Run();
    }


    //服务端 推送过来的
    public async void Run()
    {
        GrpcChannelManager.Instance.InitMainChannel(AppConfig.serverURL);
        using (ServiceManager.Instance.GetClient<PushService.PushServiceClient>(out var pushClient))
        {
            var serverPush = pushClient.ServerPush(new PushReq());
            var responseStream = serverPush.ResponseStream;
            var cancel = new CancellationTokenSource();
            // 客户端退出时或者手动断开连接时调用 Cancel
            // cancel.Cancel();
            while (true)
            {
                while (await responseStream.MoveNext(cancel.Token))
                {
                    var current = responseStream.Current;
                    EventCenter.Instance.Fire<PushRsp>(EventEnum.EE_Server_Items, current);
                    Debug.LogError(current);
                }
            }
        }

    }
}