using FairyGUI;
using UnityEngine;

namespace Login
{
    public partial class LoginMainView : GComponent
    {
        private EffectObject effObject1;

        public override void OnInit()
        {
            base.OnInit();
            FGUILoader.Instance.CheckLoadComPKG(); //加载公共依赖包

            _loginBtn.onClick.Set(OnClickLoginEnter);

            this._accountBtn.onClick.Set(() =>
            {
                // ProxyDialogTipModule.Instance.OpenDialogTip1ViewWin("提示", "正在编辑内容", "确定", null);
                Debug.LogError("测试Dispose");
                EffectLoader.Instance.Dispose(effObject1);
            });

            this._noticeBtn.onClick.Set(() =>
            {
                // ProxyLoginModule.Instance.OpenGameNoticeViewWin();
                Debug.LogError("测试加载");

                EffectLoader.Instance.LoadUIEffect("UI_zhuangbeiFR", _noticeBtn, (obj) => { effObject1 = obj; }, 0, 0);
            });

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
            var rsp = await ProtocalLogin.Instance.LoginIn(nickName);
            if (rsp?.Id > 0)
            {
                ServiceManager.Instance.SetMetaData(rsp.NickName, rsp.Id);
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
            var infos = ConfigMgr.Instance.LoadConfigDics<ItemConfig>(); //整个表
            ItemConfig config = null;
            if (infos.TryGetValue("2", out config))
            {
                Debug.LogError(config.name + "  " + config.iconDesecribe);
                ProxyCommonPKGModule.Instance.AddToastStr($"load config dicTable {config.name}   {config.iconDesecribe}");
            }

            var oneItem = ConfigMgr.Instance.LoadConfigOne<ItemConfig>("404801"); //表里的 某行数据
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