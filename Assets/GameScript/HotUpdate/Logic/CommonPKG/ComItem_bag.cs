using FairyGUI;

namespace CommonPKG
{
    public partial class ComItem_bag : GButton
    {
        private ItemDto _data;

        public void SetData(ItemDto data)
        {
            if (data != null)
            {
                var cfg = ConfigMgr.Instance.LoadConfigOne<ItemConfig>(data.cfgId.ToString());
                _hasNumTxt.text =
                    data.sum.ToString(); //BagManager.Instance.GetServerItemSum(data.cfgId).ToString();
                _itemIcon.icon = cfg.icon;
                _qualityCtrl.selectedIndex = cfg.quality - 1;
            }

            _data = data;
        }

        public ItemDto GetData()
        {
            return _data;
        }
    }
}