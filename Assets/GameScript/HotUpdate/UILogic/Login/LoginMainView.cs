using FairyGUI;
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
                ProxyDialogTipModule.Instance.OpenDialogTip1ViewWin("提示", "正在编辑内容", "确定", null);
            });

            this._noticeBtn.onClick.Set(() => { ProxyLoginModule.Instance.OpenGameNoticeViewWin(); });

            this._ageBtn.onClick.Set(() => { ProxyLoginModule.Instance.OpenGameAgeViewWin(); });

            this._serviceBtn.onClick.Set(() =>
            {
                ProxyLoginModule.Instance.OpenServerListRemoteViewWin();

                ProxyMainCenterModule.Instance.OpenMainCenterView();
                ProxyLoginModule.Instance.CloseLoginMainView();
            });

            this._sanningBtn.onClick.Set(OnClickSanningBtn);
        }



        //登录按钮
        private void OnClickLoginEnter()
        {
            var account = _roleInputTxt.text;
            if (string.IsNullOrEmpty(account) == false)
            {
                ProxyCommonPKGModule.Instance.AddToastStr("服务器开了没?");
                LoginMySql(account);
            }
            else
            {
                ProxyCommonPKGModule.Instance.AddToastStr("请先输入账号");
            }
        }

        async void LoginMySql(string nickName)
        {
            var State =await ProtocalLogin.Instance.LoginIn(nickName);
            if (State > 0)
            {
                ProxyMainCenterModule.Instance.OpenMainCenterView();
                ProxyLoginModule.Instance.CloseLoginMainView();
            }
            else
            {
                ProxyCommonPKGModule.Instance.AddToastStr("账号不存在");
            }
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
