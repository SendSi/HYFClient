using FairyGUI;
using UnityEngine.UI;

namespace Welfare
{
    public partial class TodayItem : GButton
    {
        public void SetData(TodayGiftConfig cfg)
        {
            if (cfg != null)
            {
                this._traIcon.GetController("stateCtrl").selectedIndex = cfg.iconCtrl;
                this._describeLbl.text = cfg.descTxt;
                this._titleLbl.text = cfg.titleTxt;
            }
        }
    }
}