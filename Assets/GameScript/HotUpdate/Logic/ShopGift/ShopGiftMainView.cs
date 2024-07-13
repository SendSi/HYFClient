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
        private GComponent _currChildView;
        private List<Item_ShopMenu> _menuItems = new List<Item_ShopMenu>();
        private Dictionary<string, GComponent> mMaskGComDic = new Dictionary<string, GComponent>();

        public override void OnInit()
        {
            base.OnInit();
            _menuCfg = ConfigMgr.Instance.LoadConfigList<ShopGiftMenuConfig>();
            _menuCfg.Sort((a, b) => { return a.id < b.id ? -1 : 1; });

            this._closeButton.onClick.Set(() => { ProxyShopGiftModule.Instance.CloseShopGiftMainView(); });

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

            _currChildView = CheckGetChild_ClearOld(cfg.childViewName);
            _currChildView.visible = true;
            _currChildView.data = cfg;
            _currChildView.OnInit();
        }

        GComponent CheckGetChild_ClearOld(string maskName)
        {
            if (_currChildView != null)
            {
                _currChildView.visible = false;
                // _currChildView.Dispose();//销毁了,就UI也不见了
            }

            if (mMaskGComDic.TryGetValue(maskName, out var maskView))
            {
                return maskView;
            }
            else
            {
                var maskCom = UIPackage.CreateObject("ShopGift", maskName).asCom;
                this.AddChild(maskCom); //添加到当前界面
                mMaskGComDic[maskName] = maskCom;
                return maskCom;
            }
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
            foreach (var item in _menuItems)
            {
                var tData = (ShopGiftMenuConfig)item.data;
                if (tData.id == cfgId)
                {
                    item.onClick.Call();
                    Debuger.Log("ShopGiftMainView_SetData 快到2024=" + tData.name);
                    break;
                }
            }
        }
    }
}