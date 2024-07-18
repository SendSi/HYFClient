using FairyGUI;
using cfg;

namespace ShopGift
{
    public partial class Child_MonthlyCard : GComponent
    {
        public override void OnInit()
        {
            // base.OnInit();//需盖掉
            ShopGiftMenuConfig cfg = (ShopGiftMenuConfig)(this.data);
            Debuger.Log(cfg.Name);
        }
        public void SetData()
        {
        }
    }
}