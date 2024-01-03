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
            FGUILoader.GetInstance().CheckLoadComPKG();//加载公共依赖包

            _loginBtn.onClick.Set(OnClickLoginEnter);

            this._accountBtn.onClick.Set(() =>
            {
                ProxyDialogTipModule.GetInstance().OpenDialogTip1ViewWin("提示", "正在编辑内容", "确定", null);
            });

            this._noticeBtn.onClick.Set(() => { ProxyLoginModule.GetInstance().OpenGameNoticeViewWin(); });

            this._ageBtn.onClick.Set(() => { ProxyLoginModule.GetInstance().OpenGameAgeViewWin(); });

            this._serviceBtn.onClick.Set(() => { ProxyLoginModule.GetInstance().OpenServerListRemoteViewWin(); });

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
                ProxyCommonPKGModule.GetInstance().AddToastStr("请先输入账号");
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
            //     ProxyMainCenterModule.GetInstance().OpenMainCenterView();
            //     ProxyLoginModule.GetInstance().CloseLoginMainView();
            // }
            // else
            // {
            //     ProxyCommonPKGModule.GetInstance().AddToastStr("账号不存在");
            // }
            ProxyCommonPKGModule.GetInstance().AddToastStr("~~登录同时 也飘字~~热更测试  飘字-");
            ProxyMainCenterModule.GetInstance().OpenMainCenterView();
            ProxyLoginModule.GetInstance().CloseLoginMainView();
        }

        private void OnClickSanningBtn()
        {
            Debug.LogError("测试 加载配置文件  conifg");
            var infos = ConfigMgr.GetInstance().LoadConfigDics<ItemConfig>();
            ItemConfig config = null;
            if (infos.TryGetValue("2", out config))
            {
                Debug.LogError(config.name + "  " + config.iconDesecribe);
                ProxyCommonPKGModule.GetInstance().AddToastStr($"load config dicTable {config.name}   {config.iconDesecribe}");
            }
            var oneItem = ConfigMgr.GetInstance().LoadConfigOne<ItemConfig>("404801");
            if (oneItem != null)
            {
                Debug.LogError(oneItem.name + "  " + oneItem.iconDesecribe);
                ProxyCommonPKGModule.GetInstance().AddToastStr($"load config oneLineCfg {oneItem.name}   {oneItem.iconDesecribe}");
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
