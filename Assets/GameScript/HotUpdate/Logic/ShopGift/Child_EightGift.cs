using FairyGUI;
using cfg;


namespace ShopGift
{
    public partial class Child_EightGift : GComponent
    {
        public override void OnInit()
        {
            // base.OnInit();//需盖掉
            ShopGiftMenuConfig cfg = (ShopGiftMenuConfig)(this.data);

            var list =  CfgLubanMgr.Instance.globalTab.TbEightGiftConfig.DataList;// ConfigMgr.Instance.LoadConfigList<EightGiftConfig>();
            for (int i = 1; i <= 8; i++)
            {
                var item = (Item_EightGift)GetChild($"day{i}");
                item.SetData(list[i - 1]);//Item_EightGift.cs
            }
            mNullTest.visible = false;
        }

        private GObject mNullTest;
        public void SetData()
        {
            mNullTest.visible = false;
        }
    }
}