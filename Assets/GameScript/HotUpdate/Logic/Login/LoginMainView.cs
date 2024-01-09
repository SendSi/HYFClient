// using System.Collections.Generic;
// using System.IO;
using FairyGUI;
// using Grpc.Net.Client;
// using Grpc.Net.Extensions;
// using Newtonsoft.Json;
// using server;
// using UnityEditor.Rendering;
using UnityEngine;

namespace Login
{
    public partial class LoginMainView : GComponent
    {
        public override void OnInit()
        {
            base.OnInit();
            FGUILoader.Instance.CheckLoadComPKG();//加载公共依赖包

            _loginBtn.onClick.Set(OnClickLoginEnter);

            this._accountBtn.onClick.Set(() =>
            {
                EffectLoader.Instance.LoadUIEffectEPos("UI_renwulan_1", _accountBtn ,true,EffectPos.Center);
                ProxyDialogTipModule.Instance.OpenDialogTip1ViewWin("提示", "正在编辑内容", "确定", null);
            });

            this._noticeBtn.onClick.Set(() => { ProxyLoginModule.Instance.OpenGameNoticeViewWin(); });

            this._ageBtn.onClick.Set(() => { ProxyLoginModule.Instance.OpenGameAgeViewWin(); });

            this._serviceBtn.onClick.Set(() => { ProxyLoginModule.Instance.OpenServerListRemoteViewWin(); });

            this._sanningBtn.onClick.Set(OnClickSanningBtn);
        }

        //登录按钮
        private void OnClickLoginEnter()
        {
            var account = _roleInputTxt.text;
            if (string.IsNullOrEmpty(account) == false)
            {
                LoginMySql(account);
            }
            else
            {
                ProxyCommonPKGModule.Instance.AddToastStr("请先输入账号");
            }
        }

        async void LoginMySql(string account)
        {
            // var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions()
            // {
            //     HttpHandler = new GRPCBestHttpHandler()
            // });
            //
            // var client = new RoleService.RoleServiceClient(channel);
            // var res = await client.RoleLoginAsync(new()
            // {
            //     Account = account
            // });
            // Debug.LogError($"登录结果:1成功,其他都失败______{res.State}");
            // if (res.State > 0)
            // {
            //     ProxyMainCenterModule.Instance.OpenMainCenterView();
            //     ProxyLoginModule.Instance.CloseLoginMainView();
            // }
            // else
            // {
            //     ProxyCommonPKGModule.Instance.AddToastStr("账号不存在");
            // }
            ProxyCommonPKGModule.Instance.AddToastStr("~~登录同时 也飘字~~热更测试  飘字-");
            ProxyMainCenterModule.Instance.OpenMainCenterView();
            ProxyLoginModule.Instance.CloseLoginMainView();
        }

        private void OnClickSanningBtn()
        {
            Debug.LogError("测试 加载配置文件  conifg");
            var infos = ConfigMgr.Instance.LoadConfigDics<ItemConfig>();
            ItemConfig config = null;
            if (infos.TryGetValue("2", out config))
            {
                Debug.LogError(config.name + "  " + config.iconDesecribe);
                ProxyCommonPKGModule.Instance.AddToastStr($"load config dicTable {config.name}   {config.iconDesecribe}");
            }
            var oneItem = ConfigMgr.Instance.LoadConfigOne<ItemConfig>("404801");
            if (oneItem != null)
            {
                Debug.LogError(oneItem.name + "  " + oneItem.iconDesecribe);
                ProxyCommonPKGModule.Instance.AddToastStr($"load config oneLineCfg {oneItem.name}   {oneItem.iconDesecribe}");
            }
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        public void SetData(string value)
        {
            this._title_version.text = value;
        }
    }
}
