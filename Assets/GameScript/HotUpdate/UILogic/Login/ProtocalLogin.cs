using System.Threading;
using System.Threading.Tasks;
using Grpc.Net.Client;
using HYFServer;
using UnityEngine;

public class ProtocalLogin : Singleton<ProtocalLogin>
{
    private bool isStart = true;
    private LoginService.LoginServiceClient mService;
    public async void ListenLogin(GrpcChannel channel)
    {
        mService = new LoginService.LoginServiceClient(channel);
        
        using var shopClient = mService.ListenLogin(new LoginRequest());
        var responseStream = shopClient.ResponseStream;
        var cancel = new CancellationTokenSource();
        while (isStart)
        {
            while (await responseStream.MoveNext(cancel.Token))
            {
                var current = responseStream.Current;
                Debug.LogWarning($"login:{current}");
            }
        }
    }

    protected override void OnDispose()
    {
        base.OnDispose();
        isStart = false;
    }


    public async Task<int> LoginIn(string nickName)
    {
        var res = await mService.LoginAsync(new LoginReq()
        {
            NickName = nickName
        });
        Debug.LogWarning($"1成功,其他都失败_____所以_登录结果:{res.State}");
        return res.State;
    }



}