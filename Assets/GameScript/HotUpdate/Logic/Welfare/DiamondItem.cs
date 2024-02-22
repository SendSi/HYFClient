using System;
using FairyGUI;

namespace Welfare
{
    public partial class DiamondItem : GButton
    {
        public void SetData(RechargeConfig cfg)
        {
            this._centerIcon.icon = cfg.cenIcon;
            Item extra = ItemStringUtils.Instance.GetOneItem(cfg.extraFirst);

            this._rmbLbl.text = $"{cfg.price}.00";
            this._tagTitle.text = $"赠送{extra.Num}";
            
            var coms = ItemStringUtils.Instance.GetListItem(cfg.commodity);
            this._numLbl.text = coms[0].Num.ToString();
            this._descLbl.text = $"战令经验+{coms[1].Num}";
        }
    }
}