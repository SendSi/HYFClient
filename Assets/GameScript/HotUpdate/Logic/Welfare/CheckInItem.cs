using CommonPKG;
using FairyGUI;

namespace Welfare
{
    public partial class CheckInItem : GButton
    {
        public void SetData(int dayNum)
        {
            this.title = $"第{dayNum}天";
            this._stateCtrl.selectedIndex = 0;
        }

        public void SetData(CheckInConfig cfg)
        {
            this.title = $"第{cfg.rDay}天";
            this._stateCtrl.selectedIndex = 0;
            var rightIcon = (ComItem_bag)this._propBtn;
            rightIcon.SetData(cfg.awardId, cfg.awardNum);//ComItem_bag.cs
        }
    }
}