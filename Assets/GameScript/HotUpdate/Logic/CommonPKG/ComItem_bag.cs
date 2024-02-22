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

        public void SetData(int cfgId, int num)
        {
            var cfg = ConfigMgr.Instance.LoadConfigOne<ItemConfig>(cfgId.ToString());
            _hasNumTxt.text = num.ToString();
            _itemIcon.icon = cfg.icon;
            _qualityCtrl.selectedIndex = cfg.quality - 1;
            this.mode = ButtonMode.Common;
            this._selectEle.visible = false;
        }

        public ItemDto GetData()
        {
            return _data;
        }
    }
}