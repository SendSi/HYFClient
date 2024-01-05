using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Grpc.Net.Client;
using HYFServer;
using UnityEngine;

public class ProtocalShop : Singleton<ProtocalShop>
{
    private bool isStart = true;
    private ShopService.ShopServiceClient mService;
    public async void ListenShop(GrpcChannel channel)
    {
        mService = new ShopService.ShopServiceClient(channel);
        using var shopClient = mService.ListenShop(new ShopRequest());
        var responseStream = shopClient.ResponseStream;
        var cancel = new CancellationTokenSource();
        while (isStart)
        {
            while (await responseStream.MoveNext(cancel.Token))
            {
                var current = responseStream.Current;
                Debug.LogError($"shop:{current}");
            }
        }
    }
    
    protected override void OnDispose()
    {
        base.OnDispose();
        isStart = false;
    }
}