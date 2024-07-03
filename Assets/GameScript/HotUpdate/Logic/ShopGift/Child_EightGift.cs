using FairyGUI;
using UnityEngine;


namespace ShopGift
{
    public partial class Child_EightGift : GComponent
    {
        public override void OnInit()
        {
            // base.OnInit();//需盖掉
            ShopGiftMenuConfig cfg = (ShopGiftMenuConfig)(this.data);


            var list = ConfigMgr.Instance.LoadConfigList<EightGiftConfig>();
            for (int i = 1; i <= 8; i++)
            {
                var item = (Item_EightGift)GetChild($"day{i}");
                item.SetData(list[i - 1]);
            }
        }

        public void SetData()
        {
        }
    }
}