using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using HYFServer;
using UnityEngine;

public class ProtocalRole : Singleton<ProtocalRole>
{
    private RoleService.RoleServiceClient mService;


    public async void ListenRole(GrpcChannel channel,CancellationTokenSource tokenCancel)
    {
        mService = new RoleService.RoleServiceClient(channel);
        using var roleClient = mService.ListenRole(new RoleRequest());
        var responseStream = roleClient.ResponseStream;
        try
        {
            while (await responseStream.MoveNext(tokenCancel.Token))
            {
                var current = responseStream.Current;
                Debuger.LogError($"role:{current}");
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

    public async Task<RoleUpLvResponse> RoleUpLvRequest(int lv)
    {
        Debuger.LogError($"proto请求 角色升级:{lv}");
        var res = await mService.RoleUpLvAsync(new RoleUpLvRequest()
        {
            Uid = "abc",
            Lv = lv
        });
        return res;
    }

    public async Task<RoleAddVipResponse> RoleAddVipRequest()
    {
        Debuger.LogError($"proto请求 角色vip");
        var res = await mService.RoleAddVipAsync(new RoleAddVipRequest()
        {
            Uid = "abc"
        });
        return res;
    }
}