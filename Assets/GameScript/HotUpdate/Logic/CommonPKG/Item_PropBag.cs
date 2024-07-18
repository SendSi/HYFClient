using FairyGUI;

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
                var cfg = CfgLubanMgr.Instance.globalTab.TbItemConfig.Get(data.CfgId);// ConfigMgr.Instance.LoadConfigOne<ItemConfig>(data.CfgId.ToString());
                Item_BaseProp baseProp= (Item_BaseProp)_baseProp;
                baseProp.SetData(cfg.Id,data.Sum);//Item_BaseProp.cs
            }
        }

        public void SetData(int cfgId, int num)
        {
            var cfg = CfgLubanMgr.Instance.globalTab.TbItemConfig.Get(cfgId);// ConfigMgr.Instance.LoadConfigOne<ItemConfig>(cfgId.ToString());
           Item_BaseProp baseProp= (Item_BaseProp)_baseProp;
           baseProp.SetData(cfg.Id);
            this.mode = ButtonMode.Common;
            this._selectEle.visible = false;
        }

        public ItemDto GetData()
        {
            return _data;
        }
    }
}