using System.Threading;
using System.Threading.Tasks;
using Grpc.Net.Client;
using HYFServer;
using UnityEngine;

public class ProtocalRole : Singleton<ProtocalRole>
{
    private RoleService.RoleServiceClient mService;
    private bool isStart = true;
    public async void ListenRole(GrpcChannel channel)
    {
        mService = new RoleService.RoleServiceClient(channel);
        using var shopClient = mService.ListenRole(new RoleRequest());
        var responseStream = shopClient.ResponseStream;
        var cancel = new CancellationTokenSource();
        while (isStart)
        {
            while (await responseStream.MoveNext(cancel.Token))
            {
                var current = responseStream.Current;
                Debug.LogError($"role:{current}");
            }
        }
    }
    protected override void OnDispose()
    {
        base.OnDispose();
        isStart = false;
    }

    public async Task<RoleUpLvResponse> RoleUpLvRequest(int lv)
    {
        Debug.LogError($"proto请求 角色升级:{lv}");
        var res = await mService.RoleUpLvAsync(new RoleUpLvRequest()
        {
            Uid = "abc", Lv = lv
        });
        return res;
    }

    public async Task<RoleAddVipResponse> RoleAddVipRequest()
    {
        Debug.LogError($"proto请求 角色vip");
        var res = await mService.RoleAddVipAsync(new RoleAddVipRequest()
        {
            Uid = "abc"
        });
        return res;
    }
}