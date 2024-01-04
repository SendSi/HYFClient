using System.Threading.Tasks;
using HYFServer;
using UnityEngine;

public class ProtocalLogin : Singleton<ProtocalLogin>
{
    private LoginService.LoginServiceClient mService;

    protected override void OnInit()
    {
        base.OnInit();
        mService = new LoginService.LoginServiceClient(GrpcChannelManager.Instance.MainChannel);
    }


    public async Task<int> LoginIn(string nickName)
    {
        var res = await mService.LoginAsync(new LoginReq()
        {
            NickName = nickName
        });
        Debug.LogError($"1成功,其他都失败_____所以_登录结果:{res.State}");
        return  res.State;
    }



}
