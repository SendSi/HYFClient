﻿using System.Collections.Generic;
using FairyGUI;
using cfg;
namespace Welfare
{
    public partial class Child_DiamondView : GComponent
    {
        private List<RechargeConfig> _cfgInfos;

        public override void OnInit()
        {
            base.OnInit();

            WelfareMenuConfig cfg = (WelfareMenuConfig)(this.data);
            Debuger.LogError(cfg.Name);

            _cfgInfos = CfgLubanMgr.Instance.globalTab.TbRechargeConfig.DataList;// ConfigMgr.Instance.LoadConfigList<RechargeConfig>(); //整个表
            _cfgInfos.Sort((a, b) => { return a.Id < b.Id ? -1 : 1; });

            this._diamondList.itemRenderer = OnRendererDiamond;
            this._diamondList.numItems = 6;

            this._goWarBtn.onClick.Set(OnClickGoWarBtn);
            this._curProSlider.max = 250;
            this._curProSlider.value = 120;
        }

        private void OnClickGoWarBtn()
        {
            Debuger.LogError("前往战令");
        }

        private void OnRendererDiamond(int index, GObject item)
        {
            var rec = _cfgInfos[index];
            DiamondItem obj = (DiamondItem)item;
            obj.SetData(rec);//DiamondItem.cs
        }
    }
}