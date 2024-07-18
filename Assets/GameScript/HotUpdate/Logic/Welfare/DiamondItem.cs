using cfg;
using FairyGUI;

namespace Welfare
{
    public partial class DiamondItem : GButton
    {
        public void SetData(RechargeConfig cfg)
        {
            this._centerIcon.icon = cfg.CenIcon;
            Item extra = ItemStringUtils.Instance.GetOneItem(cfg.ExtraFirst);

            this._rmbLbl.text = $"{cfg.Price}.00";
            this._tagTitle.text = $"赠送{extra.Num}";

            var coms = cfg.Commodity;//ItemStringUtils.Instance.GetListItem(cfg.Commodity);
            this._numLbl.text = coms[0].Num.ToString();
            this._descLbl.text = $"战令经验+{coms[1].Num}";
        }
    }
}