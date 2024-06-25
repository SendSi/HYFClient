using FairyGUI;
using UnityEngine;
#region << 脚 本 注 释 >>
//作  用:    ProtocalShopGift
//作  者:    曾思信
//创建时间:  #CREATETIME#
#endregion

namespace ShopGift
{
    public partial class Item_ShopType : GComponent
    {
        public void SetData(ShopGiftMenuConfig cfg)
        {
            this._title.text = cfg.name;
        }
    }
}
