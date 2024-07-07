using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using HYFServer;
using UnityEngine;

public class ProtocalLogin : Singleton<ProtocalLogin>
{
    private LoginService.LoginServiceClient mService;

    public async void ListenLogin(GrpcChannel channel,CancellationTokenSource tokenCancel)
    {
        mService = new LoginService.LoginServiceClient(channel);

        using var loginClient = mService.ListenLogin(new LoginRequest());
        var responseStream = loginClient.ResponseStream;

        try
        {
            while (await responseStream.MoveNext(tokenCancel.Token))
            {
                var current = responseStream.Current;
                Debuger.LogWarning($"login:{current}");
            }
        }
        catch (RpcException ex) when (ex.StatusCode == StatusCode.Cancelled && tokenCancel.IsCancellationRequested)
        {
            // Debuger.LogError("Cancelled");
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


    public async Task<LoginRsp> LoginIn(string nickName)
    {
        var res = await mService.LoginInAsync(new LoginReq()
        {
            NickName = nickName
        });
        Debuger.LogWarning($"大于0成功,其他都失败_____所以_登录结果:{res.Id}");
        return res;
    }



}