using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

namespace Welfare
{
    public partial class Child_DiamondView : GComponent
    {
        private List<RechargeConfig> _cfgInfos;

        public override void OnInit()
        {
            base.OnInit();

            WelfareMenuConfig cfg = (WelfareMenuConfig)(this.data);
            Debug.LogError(cfg.name);

            _cfgInfos = ConfigMgr.Instance.LoadConfigList<RechargeConfig>(); //整个表
            _cfgInfos.Sort((a, b) => { return a.id < b.id ? -1 : 1; });

            this._diamondList.itemRenderer = OnRendererDiamond;
            this._diamondList.numItems = 6;

            this._goWarBtn.onClick.Set(OnClickGoWarBtn);
            this._curProSlider.max = 250;
            this._curProSlider.value = 120;
        }

        private void OnClickGoWarBtn()
        {
            Debug.LogError("前往战令");
        }

        private void OnRendererDiamond(int index, GObject item)
        {
            var rec = _cfgInfos[index];
            DiamondItem obj = (DiamondItem)item;
            obj.SetData(rec);//DiamondItem.cs
        }
    }
}