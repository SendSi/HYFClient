using FairyGUI;
using cfg;

namespace CommonPKG
{
    public partial class Item_Popup1 : GComponent
    {
        public void SetData(ItemProp item)
        {
            var cfg = CfgLubanMgr.Instance.globalTab.TbItemConfig.Get(item.Id); //ConfigMgr.Instance.LoadConfigOne<ItemConfig>(item.id.ToString());
            this._title.text = cfg.Name;
            this._itemDescTxt.text = CfgLubanMgr.Instance.GetCurrLangCfgTxt(cfg.DescLangId, cfg.Desc);
            this._comItem.SetData(item, false);
        }
    }
}