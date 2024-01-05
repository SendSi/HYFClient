using System.Threading;
using System.Threading.Tasks;
using Grpc.Net.Client;
using HYFServer;
using UnityEngine;

public class ProtocalBag : Singleton<ProtocalBag>
{
    private BagService.BagServiceClient mService;
    private bool isStart = true;
    public async void ListenBag(GrpcChannel channel)
    {
        mService = new BagService.BagServiceClient(channel);
        
        using var shopClient = mService.ListenBag(new BagRequest());
        var responseStream = shopClient.ResponseStream;
        var cancel = new CancellationTokenSource();
        while (isStart)
        {
            while (await responseStream.MoveNext(cancel.Token))
            {
                var current = responseStream.Current;
                Debug.LogError($"bag:{current}");
            }
        }
    }
    protected override void OnDispose()
    {
        base.OnDispose();
        isStart = false;
    }


    public async Task  OpenBag()
    {
        Debug.LogError($"proto请求 OpenBag");
        var bagT = mService.OpenBag();
        var cancel = new CancellationToken();
        var responseReaderTask = Task.Run(async () =>
        {
            while (await bagT.ResponseStream.MoveNext(cancel))
            {
                var response = bagT.ResponseStream.Current;
                Debug.LogError(response);
            }
        });
        
        // 完成请求
        await bagT.RequestStream.CompleteAsync();
        await responseReaderTask;
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



}