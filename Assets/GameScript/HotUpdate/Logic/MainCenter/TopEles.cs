using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

namespace MainCenter
{
    public partial class TopEles : GComponent
    {
        private List<FuncBtnData> _listData = new List<FuncBtnData>()
        {
            new FuncBtnData(2001, "ui://CommonPKG/activity_003", "功能预告", () =>
            {
            }),
            new FuncBtnData(2002, "ui://CommonPKG/activity_016", "活动", () => { }),
            new FuncBtnData(2003, "ui://CommonPKG/activity_007", "福利", () => { ProxyWelfareModule.Instance.OpenWelfareMainView(); }),
        };

        public override void OnInit()
        {
            base.OnInit();
            _mainPlayerBtn.onClick.Set(OnClickMainPlayerBtn);
            _settingBtn.onClick.Set(OnClickSettingBtn);
            _funcList.itemRenderer = OnClickItemFuncList;
            _funcList.numItems = _listData.Count;

            EventCenter.Instance.Bind<string>(EventEnum.EE_test, OnEventTest);
        }

        private void OnClickItemFuncList(int index, GObject obj)
        {
            Main_FuncTop item = (Main_FuncTop)obj;
            item.SetData(_listData[index]); //Main_FuncTop.cs
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