using System;
using System.Collections.Generic;
using FairyGUI;
// using Framework;

namespace MainCenter
{
    public partial class FuncListEles : GComponent
    {
        private FuncListEles mView;

        private List<FuncBtnData> _listData = new List<FuncBtnData>()
        {
            new FuncBtnData("ui://MainCenter/btn_hero", "英雄",
                () =>
                {
                    EventCenter.GetInstance().Fire<string>(EventEnum.EE_test,"event可能是dto");
                    // EventSystem.Instance.FireAction(MainCenterEvents.Test1, "英雄");
                    // EventCenter.GetInstance().Fire<int>(EventEnum.EN_gameOver,100);
                }),
            new FuncBtnData("ui://MainCenter/btn_league", "联盟", () => { }),
            new FuncBtnData("ui://MainCenter/btn_bag", "背包", () => { ProxyBagModule.GetInstance().OpenBagMainView(); }),
            new FuncBtnData("ui://MainCenter/btn_email", "邮件", () => { }),
            new FuncBtnData("ui://MainCenter/btn_arm", "部队",
                () =>
                {
                    ProxyCommonPKGModule.GetInstance().AddToastStr("~~~~简易 飘字---挺长的飘字哦....");
                }),
        };

        public override void OnInit()
        {
            base.OnInit();

            _btnFuncList.itemRenderer = ListItemRenderer;
            _btnFuncList.numItems = _listData.Count;
        }

        private void ListItemRenderer(int index, GObject obj)
        {
            main_btn item = (main_btn)obj;
            item.SetData(_listData[index]);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }

    public class FuncBtnData
    {
        public string _iconURL;
        public string _titleTxt;
        public Action _clikcAct;

        public FuncBtnData(string iconURL, string titleTxt)
        {
            _iconURL = iconURL;
            _titleTxt = titleTxt;
        }

        public FuncBtnData(string iconURL, string titleTxt, Action clickAct)
        {
            _iconURL = iconURL;
            _titleTxt = titleTxt;
            _clikcAct = clickAct;
        }
    }
}
