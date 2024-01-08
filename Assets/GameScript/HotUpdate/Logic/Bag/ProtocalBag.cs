using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using HYFServer;
using UnityEngine;

public class ProtocalBag : Singleton<ProtocalBag>
{
    private BagService.BagServiceClient mService;

    public async void ListenBag(GrpcChannel channel, CancellationTokenSource tokenCancel)
    {
        mService = new BagService.BagServiceClient(channel);
        using var bagClient = mService.ListenBag(new BagRequest());
        var responseStream = bagClient.ResponseStream;
        try
        {
            while (await responseStream.MoveNext(tokenCancel.Token))
            {
                var current = responseStream.Current;
                Debug.LogError($"bag-stream-->{current}");
                OnEventServicePush(current);
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

    private void OnEventServicePush(BagResponse rsp)
    {
        switch (rsp.BagMsgCase)
        {
            case BagResponse.BagMsgOneofCase.ItemInfos:
                BagManager.Instance.SetServerItems(rsp.ItemInfos);
                break;
        }
    }


    public async Task OpenBag()
    {
        var meta = ServiceManager.Instance.GetMetaData();
        Debug.LogError($"ProtocalBag请求OpenBag--登录完之后 都要顺发送metaData");
        var res = await mService.OpenBagAsync(new OpenBagRequest(), meta);

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < res.Items.Count; i++)
        {
            sb.Append(res.Items[i].ToString()+"<<-->>");
        }
        Debug.LogError(sb.ToString());
    }

    public async Task<BagUsingItemResponse> BagUsingItem(int cfgId, int num)
    {
        var usCall = await mService.BagUsingItemAsync(new BagUsingItemRequest() { CfgId = cfgId, Num = num });
        return usCall;
    }
}
