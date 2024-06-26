using FairyGUI;
using UnityEngine;

namespace ShopGift
{
    public partial class Child_MonthlyCard : GComponent
    {
        public override void OnInit()
        {
            base.OnInit();
            ShopGiftMenuConfig cfg = (ShopGiftMenuConfig)(this.data);
            Debug.LogError(cfg.name);
        }
        public void SetData()
        {
        }
    }
}