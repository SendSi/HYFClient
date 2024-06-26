using System.Collections.Generic;
using CommonPKG;
using FairyGUI;
using UnityEngine;

namespace MainCenter
{
    public partial class MainTopEles : GComponent
    {
        private List<MainUIBtnConfig> mCfgList;

        private List<int> mCurrencyIds = new List<int>() { 1, 2, 5, 12 };

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

            EventCenter.Instance.Bind<string>(EventEnum.EE_test, OnEventTest);
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
            Debug.LogError("TopEles 监听了 EN_test_" + arg0);
        }

        private void OnEventTest1(string text)
        {
            Debug.LogError("TopEles 监听了 EN_test:" + text);
        }

        private void OnClickMainPlayerBtn()
        {
            ProxyMainRoleModule.Instance.OpenRoleMainViewWin();
        }

        public override void Dispose()
        {
            base.Dispose();
            EventCenter.Instance.UnBind<string>(EventEnum.EE_test, OnEventTest);
        }
    }
}