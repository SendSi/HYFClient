using System.Threading.Tasks;
using HYFServer;
using UnityEngine;

public class ProtocalRole : Singleton<ProtocalRole>
{
    private RoleService.RoleServiceClient mService;

    protected override void OnInit()
    {
        base.OnInit();
        mService = new RoleService.RoleServiceClient(GrpcChannelManager.Instance.MainChannel);
    }


    public async Task<RoleUpLvResponse> RoleUpLvRequest(int lv)
    {
        Debug.LogError($"proto请求 角色升级:{lv}");
        var res = await mService.RoleUpLvAsync(new RoleUpLvRequest()
        {
           Uid = "abc",Lv = lv
        });
        return  res;
    }

    public async Task<RoleAddVipResponse> RoleAddVipRequest()
    {
        Debug.LogError($"proto请求 角色vip");
        var res = await mService.RoleAddVipAsync(new RoleAddVipRequest()
        {
         Uid = "abc"
        });
        return  res;
    }

}
