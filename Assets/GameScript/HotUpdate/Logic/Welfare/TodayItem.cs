using FairyGUI;
using cfg;
namespace Welfare
{
    public partial class TodayItem : GButton
    {
        public void SetData(TodayGiftConfig cfg)
        {
            if (cfg != null)
            {
                this._traIcon.GetController("stateCtrl").selectedIndex = cfg.IconCtrl;
                this._describeLbl.text = cfg.DescTxt;
                this._titleLbl.text = cfg.TitleTxt;
            }
        }
    }
}