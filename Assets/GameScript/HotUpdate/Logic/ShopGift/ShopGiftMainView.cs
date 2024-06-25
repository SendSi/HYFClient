using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

#region << 脚 本 注 释 >>

//作  用:    ShopGiftMainView
//作  者:    曾思信
//创建时间:  #CREATETIME#

#endregion

namespace ShopGift
{
    
    public partial class ShopGiftMainView : GComponent
    {
        private List<ShopGiftMenuConfig> _menuCfg;
        private Item_ShopMenu _currMenuItem;
        private List<Item_ShopMenu> _menuItems = new List<Item_ShopMenu>();
        public override void OnInit()
        {
            base.OnInit();
          _menuCfg = ConfigMgr.Instance.LoadConfigList<ShopGiftMenuConfig>();
            _menuCfg.Sort((a, b) =>            {                return a.id < b.id ? -1 : 1; });

            this._closeButton.onClick.Set(() => { ProxyShopGiftModule.Instance.CloseShopGiftMainView();});

            this._leftTabList.itemRenderer = OnRendererTabList;
            this._leftTabList.itemProvider = OnProviderTabList;
            this._leftTabList.onClickItem.Add(OnClickItemLeftTab);
            _menuItems.Clear();
            this._leftTabList.numItems = _menuCfg.Count; //mMenuDtos.Count;
        }

        private void OnClickItemLeftTab(EventContext evCon)
        {
            var data = (GComponent)evCon.data;
            ShopGiftMenuConfig cfg = (ShopGiftMenuConfig)data.data;

            // this._conPanel.url = cfg.urlPath;
            // this._conPanel.component.data = cfg;
            // this._conPanel.component.OnInit(); //点击使用
        }

        private string OnProviderTabList(int index)
        {
            return _menuCfg[index].rType == 0 ? "ui://ShopGift/Item_ShopType" : "ui://ShopGift/Item_ShopMenu";
        }

        private void OnRendererTabList(int index, GObject obj)
        {
            var cfg = _menuCfg[index];
            obj.data = cfg;

            if (cfg.rType == 0)
            {
                Item_ShopType item = (Item_ShopType)obj;
                item.SetData(cfg);
            }
            else
            {
                Item_ShopMenu item = (Item_ShopMenu)obj;
                item.SetData(cfg);
                _menuItems.Add(item);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            _menuItems.Clear();
        }

        public void SetData(int cfgId)
        {
            Debug.LogError("WelfareMainView_SetData");
            // foreach (var item in _menuItems)
            // {
            //     var tData = (WelfareMenuConfig)item.data;
            //     if (tData.id == cfgId)
            //     {
            //         item.onClick.Call();
            //         break;
            //     }
            // }
        }
    }
}