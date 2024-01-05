using System.Threading;
using Grpc.Net.Client;
using HYFServer;
using UnityEngine;

public class ProtocalShop : Singleton<ProtocalShop>
{
    private bool isStart = true;
    private ShopService.ShopServiceClient mClient;

    public async void ListenShop(GrpcChannel channel)
    {
        mClient = new ShopService.ShopServiceClient(channel);
        using var shopClient = mClient.ListenShop(new ShopRequest());
        var responseStream = shopClient.ResponseStream;
        var cancel = new CancellationTokenSource();
        while (isStart)
        {
            while (await responseStream.MoveNext(cancel.Token))
            {
                var current = responseStream.Current;
                Debug.LogError($"shop->stream:{current}");
            }
        }
    }

    protected override void OnDispose()
    {
        base.OnDispose();
        isStart = false;
    }
}