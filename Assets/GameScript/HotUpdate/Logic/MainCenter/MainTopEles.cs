using System.Collections.Generic;
using CommonPKG;
using FairyGUI;
using cfg;

namespace MainCenter
{
    public partial class MainTopEles : GComponent
    {
        private List<MainUIBtnConfig> mCfgList;

        private List<int> mCurrencyIds = new List<int>() { 1001, 1002, 1005, 1011 };

        public override void OnInit()
        {
            base.OnInit();
            _mainPlayerBtn.onClick.Set(OnClickMainPlayerBtn);
            _settingBtn.onClick.Set(OnClickSettingBtn);
            _funcList.itemRenderer = OnClickItemFuncList;

            mCfgList = MainCenterManager.Instance.GetMainUIBtnList(2);
            _funcList.numItems = mCfgList.Count;

            CurrencyListCom currencyListCom = (CurrencyListCom)_currencyListCom;
            currencyListCom.SetData(mCurrencyIds); //CurrencyListCom.cs

            EventCenter.Instance.Bind<string>((int)EventEnum.EE_test, OnEventTest);
        }

        private void OnClickItemFuncList(int index, GObject obj)
        {
            MainTopBtn item = (MainTopBtn)obj;
            item.SetData(mCfgList[index]); //MainTopBtn.cs
        }

        private void OnClickSettingBtn(EventContext context)
        {
            ProxySettingPKGModule.Instance.OpenSettingPKGViewWin();
        }

        private void OnEventTest(string arg0)
        {
            Debuger.LogError("TopEles 监听了 EN_test_" + arg0);
        }

        private void OnEventTest1(string text)
        {
            Debuger.LogError("TopEles 监听了 EN_test:" + text);
        }

        private void OnClickMainPlayerBtn()
        {
            ProxyMainRoleModule.Instance.OpenRoleMainViewWin();
        }

        public override void Dispose()
        {
            base.Dispose();
            EventCenter.Instance.UnBind<string>((int)EventEnum.EE_test, OnEventTest);
        }
    }
}