using System;
using System.Threading;
using Grpc.Core;
using Grpc.Net.Client;
using HYFServer;
using UnityEngine;

public class ProtocalShop : Singleton<ProtocalShop>
{
    private ShopService.ShopServiceClient mService;

    public async void ListenShop(GrpcChannel channel, CancellationTokenSource tokenCancel)
    {
        mService = new ShopService.ShopServiceClient(channel);
        using var shopClient = mService.ListenShop(new ShopRequest());
        var responseStream = shopClient.ResponseStream;
        try
        {
            while (await responseStream.MoveNext(tokenCancel.Token))
            {
                var current = responseStream.Current;
                Debug.LogError($"shop->stream:{current}");
            }
        }
        catch (RpcException ex) when (ex.StatusCode == StatusCode.Cancelled && tokenCancel.IsCancellationRequested)
        {
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }

    protected override void OnDispose()
    {
        base.OnDispose();
    }
}