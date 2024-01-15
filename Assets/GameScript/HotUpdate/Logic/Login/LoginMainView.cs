using FairyGUI;
using UnityEngine;

namespace Login
{
    public partial class LoginMainView : GComponent
    {
        private EffectObject effObject1;
        private int _currComValue = 0;

        public override void OnInit()
        {
            base.OnInit();
            FGUILoader.Instance.CheckLoadComPKG(); //加载公共依赖包
            AudioMgr.Instance.PlayBGM("music_background");
            ProxyCommonPKGModule.Instance.LoadToastTipView();//要加载出来 tip

            // Debug.LogError(ConfigMgr.Instance.GetCurrLangCfgTxt("1001"));
            // Debug.LogError(ConfigMgr.Instance.GetCurrLangScriptTxt("1001"));

            _loginBtn.onClick.Set(OnClickLoginEnter);

            this._accountBtn.onClick.Set(() =>
            {
                ProxyDialogTipModule.Instance.OpenDialogTip1ViewWin("提示", "正在编辑内容", "确定", null);
            });

            this._noticeBtn.onClick.Set(() =>
            {
                // ProxyLoginModule.Instance.OpenGameNoticeViewWin();
                Debug.LogError("测试加载");

                EffectLoader.Instance.LoadUIEffectEPos("UI_renwulan_1", _noticeBtn, false, EffectPos.Center, (obj) =>
                {
                    effObject1 = obj;
                });
            });

            this._ageBtn.onClick.Set(() =>
            {
                ProxyLoginModule.Instance.OpenGameAgeViewWin();
                //effObject1.Stop();
            });

            this._serviceBtn.onClick.Set(() =>
            {
                ProxyLoginModule.Instance.OpenServerListRemoteViewWin();

                ProxyMainCenterModule.Instance.OpenMainCenterView();
                ProxyLoginModule.Instance.CloseLoginMainView();
            });


            this._sanningBtn.onClick.Set(OnClickSanningBtn);
            // 简体中文SimChinese  繁体中文TraChinese  英文English 
            if (AppConfig.currLang == "SimChinese") { _currComValue = 0; }
            else if (AppConfig.currLang == "TraChinese") { _currComValue = 1; }
            else if (AppConfig.currLang == "English ") { _currComValue = 2; }

            _languCom.selectedIndex = _currComValue;
            this._languCom.items = new[] { "简体中文", "繁體中文", "English" };
            this._languCom.onChanged.Set(OnChangedLanguage);
        }

        private void OnChangedLanguage()
        {
            if (_currComValue == _languCom.selectedIndex)
            {
                return; //本就选中 当前语言
            }

            var content = $"您确定要切换成{this._languCom.title},\r\n游戏将退出,重启后再成为目标语言";
            ProxyDialogTipModule.Instance.OpenDialogTip2ViewWin("提示", content, null, delegate
            {
                _languCom.selectedIndex = _currComValue;
                _languCom.title = this._languCom.items[_currComValue];
            }, null, delegate
            {
                if (this._languCom.selectedIndex == 0) { LanguageUtils.Instance.ChangeLanguage("SimChinese"); }
                else if (this._languCom.selectedIndex == 1) { LanguageUtils.Instance.ChangeLanguage("TraChinese"); }
                else if (this._languCom.selectedIndex == 2) { LanguageUtils.Instance.ChangeLanguage("English"); }
            });
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