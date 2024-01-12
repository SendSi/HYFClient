using System;
using System.Collections.Generic;
using FairyGUI;

namespace MainCenter
{
    public partial class FuncListEles : GComponent
    {
        private FuncListEles mView;

        private List<FuncBtnData> _listData = new List<FuncBtnData>()
        {
            new FuncBtnData(1001, "ui://MainCenter/btn_hero", "英雄",
                () => { EventCenter.Instance.Fire<string>(EventEnum.EE_test, "event可能是dto"); }),
            new FuncBtnData(1002, "ui://MainCenter/btn_league", "联盟", () =>
            {
                AudioMgr.Instance.PlayBGM("sound_explosion_enemy");
            }),
            new FuncBtnData(1003, "ui://MainCenter/btn_bag", "背包",
                () => { ProxyBagModule.Instance.OpenBagMainView(); }),
            new FuncBtnData(1004, "ui://MainCenter/btn_email", "邮件", () =>
            {
                EffectLoader.Instance.LoadSceneEffectSimple("TX_BYCH_Skill");
                AudioMgr.Instance.PlayMusic("sound_weapon_player");
            }),
            new FuncBtnData(1005, "ui://MainCenter/btn_arm", "部队",
                () => { ProxyCommonPKGModule.Instance.AddToastStr("~~~~简易 飘字---挺长的飘字哦...."); }),
        };

        public override void OnInit()
        {
            base.OnInit();

            _btnFuncList.itemRenderer = ListItemRenderer;
            _btnFuncList.numItems = _listData.Count;
        }

        private void ListItemRenderer(int index, GObject obj)
        {
            Main_btn item = (Main_btn)obj;
            item.SetData(_listData[index]); //Main_btn.cs
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }

    public class FuncBtnData
    {
        public int fId { get; set; } //1001英雄  1002联盟 1003背包 1004邮件 1005部队
        public string iconURL { get; set; }
        public string titleTxt { get; set; }
        public Action clikcAct { get; set; }

        public FuncBtnData(string iconURL, string titleTxt)
        {
            this.iconURL = iconURL;
            this.titleTxt = titleTxt;
        }

        public FuncBtnData(int id, string iconURL, string titleTxt, Action clickAct)
        {
            this.fId = id;
            this.iconURL = iconURL;
            this.titleTxt = titleTxt;
            this.clikcAct = clickAct;
        }
    }
}