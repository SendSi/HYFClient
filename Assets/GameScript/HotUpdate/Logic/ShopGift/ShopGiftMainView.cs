using System.Collections.Generic;
using FairyGUI;
using UnityEngine;
using cfg;

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
            _menuCfg = CfgLubanMgr.Instance.globalTab.TbShopGiftMenuConfig
                .DataList; //ConfigMgr.Instance.LoadConfigList<ShopGiftMenuConfig>();
            _menuCfg.Sort((a, b) => { return a.Id < b.Id ? -1 : 1; });

            this._closeButton.onClick.Set(() => { ProxyShopGiftModule.Instance.CloseShopGiftMainView(); });

            this._leftTabList.itemRenderer = OnRendererTabList;
            this._leftTabList.itemProvider = OnProviderTabList;
            this._leftTabList.onClickItem.Add(OnClickItemLeftTab);
            _menuItems.Clear();
            this._leftTabList.numItems = _menuCfg.Count; //mMenuDtos.Count;

            EventCenter.Instance.Bind<string>((int)EventEnum.EE_test3, OnEventTest3);
            EventCenter.Instance.Bind<string>((int)EventEnum.EE_test2, OnEventTest2_Wait);
        }

        private void OnEventTest2_Wait(string arg0)
        {
            Debuger.LogError("使用Event的缓几帧执行 " + Time.frameCount + "    " + arg0);
        }

        private void OnEventTest3(string arg0)
        {
            Debuger.LogError(Time.frameCount + "    " + arg0);
        }

        private void OnClickItemLeftTab(EventContext evCon)
        {
            var data = (GComponent)evCon.data;
            ShopGiftMenuConfig cfg = (ShopGiftMenuConfig)data.data;

            _currChildView = CheckGetChild_ClearOld(cfg.ChildViewName);
            _currChildView.visible = true;
            _currChildView.data = cfg;
            _currChildView.OnInit();

            Debuger.LogError(Time.frameCount + " 发送时frameCount");
            EventCenter.Instance.Fire<string>((int)EventEnum.EE_test3, cfg.Name);
            EventCenter.Instance.Fire_Wait<string>((int)EventEnum.EE_test2, cfg.ChildViewName, 5);
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
            return _menuCfg[index].RType == 0 ? "ui://ShopGift/Item_ShopType" : "ui://ShopGift/Item_ShopMenu";
        }

        private void OnRendererTabList(int index, GObject obj)
        {
            var cfg = _menuCfg[index];
            obj.data = cfg;

            if (cfg.RType == 0)
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

            EventCenter.Instance.UnBind<string>((int)EventEnum.EE_test3, OnEventTest3);
            EventCenter.Instance.UnBind<string>((int)EventEnum.EE_test2, OnEventTest2_Wait);
        }

        public void SetData(int cfgId)
        {
            foreach (var item in _menuItems)
            {
                var tData = (ShopGiftMenuConfig)item.data;
                if (tData.Id == cfgId)
                {
                    item.onClick.Call();
                    Debuger.Log("ShopGiftMainView_SetData 快到2024=" + tData.Name);
                    break;
                }
            }
        }
    }
}