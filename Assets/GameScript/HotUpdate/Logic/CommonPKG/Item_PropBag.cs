using FairyGUI;
using HYFServer;

namespace CommonPKG
{
    public partial class Item_PropBag : GButton
    {
        private ItemDto _data;

        public void SetData(ItemDto data)
        {
            _data = data;
            if (data != null)
            {
                var cfg = ConfigMgr.Instance.LoadConfigOne<ItemConfig>(data.CfgId.ToString());
                Item_BaseProp baseProp= (Item_BaseProp)_baseProp;
                baseProp.SetData(cfg.id,data.Sum);//Item_BaseProp.cs
            }
        }

        public void SetData(int cfgId, int num)
        {
            var cfg = ConfigMgr.Instance.LoadConfigOne<ItemConfig>(cfgId.ToString());
           Item_BaseProp baseProp= (Item_BaseProp)_baseProp;
           baseProp.SetData(cfg.id);
            this.mode = ButtonMode.Common;
            this._selectEle.visible = false;
        }

        public ItemDto GetData()
        {
            return _data;
        }
    }
}