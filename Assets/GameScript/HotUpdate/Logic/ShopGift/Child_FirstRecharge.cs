using FairyGUI;
using UnityEngine;


namespace ShopGift
{
    public partial class Child_FirstRecharge : GComponent
    {
        public override void OnInit()
        {
            // base.OnInit();//需盖掉
            ShopGiftMenuConfig cfg = (ShopGiftMenuConfig)(this.data);
            Debug.LogError(cfg.name);
        }
        public void SetData()
        {
        }
    }
}