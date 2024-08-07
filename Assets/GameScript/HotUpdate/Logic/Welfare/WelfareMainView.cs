using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

namespace Welfare
{
    public partial class WelfareMainView : GComponent
    {
        private List<cfg.WelfareMenuConfig> _menuCfg;
        private List<MenuItemWelfare> _menuItems = new List<MenuItemWelfare>();

        public override void OnInit()
        {
            base.OnInit();

            _menuCfg =  CfgLubanMgr.Instance.globalTab.TbWelfareMenuConfig.DataList;//ConfigMgr.Instance.LoadConfigList<WelfareMenuConfig>();
            _menuCfg.Sort((a, b) =>            {                return a.Id < b.Id ? -1 : 1; });

            this._closeButton.onClick.Set(() => { ProxyWelfareModule.Instance.CloseWelfareMainView(); });

            this._leftTabList.itemRenderer = OnRendererTabList;
            this._leftTabList.itemProvider = OnProviderTabList;
            this._leftTabList.onClickItem.Add(OnClickItemLeftTab);
            _menuItems.Clear();
            this._leftTabList.numItems = _menuCfg.Count; //mMenuDtos.Count;
        }

        private void OnClickItemLeftTab(EventContext evCon)
        {
            var data = (GComponent)evCon.data;
            cfg.WelfareMenuConfig cfg = (cfg.WelfareMenuConfig)data.data;

            this._conPanel.url = cfg.UrlPath;
            this._conPanel.component.data = cfg;
            this._conPanel.component.OnInit(); //点击使用
        }

        private string OnProviderTabList(int index)
        {
            return _menuCfg[index].RType == 0 ? "ui://Welfare/MenuTypeWelfare" : "ui://Welfare/MenuItemWelfare";
        }

        private void OnRendererTabList(int index, GObject obj)
        {
            var cfg = _menuCfg[index];
            obj.data = cfg;

            if (cfg.RType == 0)
            {
                MenuTypeWelfare item = (MenuTypeWelfare)obj;
                item.SetData(cfg);
            }
            else
            {
                MenuItemWelfare item = (MenuItemWelfare)obj;
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
                var tData = (cfg.WelfareMenuConfig)item.data;
                if (tData.Id == cfgId)
                {
                    item.onClick.Call();
                    break;
                }
            }
        }
    }
}