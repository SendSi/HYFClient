using FairyGUI;

namespace CommonPKG
{
    public partial class Item_Popup1 : GComponent
    {
        public void SetData(ItemProp item)
        {
            var cfg = ConfigMgr.Instance.LoadConfigOne<ItemConfig>(item.id.ToString());
            this._title.text = cfg.name;
            this._itemDescTxt.text = cfg.iconDesecribe;
            this._comItem.SetData(item, false);
        }
    }
}