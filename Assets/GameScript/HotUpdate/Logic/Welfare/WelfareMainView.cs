using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

namespace Welfare
{
    public class MenuData
    {
        public int _id { get; set; }
        public string _name { get; set; }
        public int _type { get; set; } //0分类   1具体活动
        public string _urlPath { get; set; }

        public MenuData(int id, string name, int type, string urlPath)
        {
            this._id = id;
            this._name = name;
            this._type = type;
            this._urlPath = urlPath;
        }
    }

    public partial class WelfareMainView : GComponent
    {
        private List<MenuData> mMenuDtos = new List<MenuData>()
        {
            new MenuData(1000, "新手活动", 0, null),
            new MenuData(1001, "每日签到", 1, "ui://Welfare/Child_CheckInView"),
            new MenuData(1002, "钻石充值", 1, "ui://Welfare/Child_DiamondView"),
            new MenuData(1003, "超值祈愿", 1, "ui://Welfare/Child_WishView"),
            new MenuData(2000, "日常活动", 0, null),
            new MenuData(2001, "优惠宝箱", 1, "ui://Welfare/Child_TodayView"),
            new MenuData(2002, "联盟圣兽", 1, "ui://Welfare/Child_ThanatorView"),
            new MenuData(2003, "世界BOSS", 1, "ui://Welfare/Child_WorldBossView"),
        };

        private MenuItemWelfare _currMenuItem;
        private List<MenuItemWelfare> _menuItems=new List<MenuItemWelfare>();
        

        public override void OnInit()
        {
            base.OnInit();

            this._closeButton.onClick.Set(() => { ProxyWelfareModule.Instance.CloseWelfareMainView(); });

            this._leftTabList.itemRenderer = OnRendererTabList;
            this._leftTabList.itemProvider = OnProviderTabList;
            this._leftTabList.onClickItem.Add(OnClickItemLeftTab);
            _menuItems.Clear();
            this._leftTabList.numItems = mMenuDtos.Count;
        }

        private void OnClickItemLeftTab(EventContext evCon)
        {
            var data = (GComponent)evCon.data;
            MenuData cfg = (MenuData)data.data;

            this._conPanel.url = cfg._urlPath;
            this._conPanel.component.data = cfg;
            this._conPanel.component.OnInit();//点击使用
        }

        private string OnProviderTabList(int index)
        {
            return mMenuDtos[index]._type == 0 ? "ui://Welfare/MenuTypeWelfare" : "ui://Welfare/MenuItemWelfare";
        }

        private void OnRendererTabList(int index, GObject obj)
        {
            var cfg = mMenuDtos[index];
            obj.data = cfg;
            
            if (cfg._type == 0)
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
            Debug.LogError("WelfareMainView_SetData");
            for (int i = 0; i < _menuItems.Count; i++)
            {
                var tData = (MenuData)_menuItems[i].data;
                if (tData._id == cfgId)
                {
                    _menuItems[i].onClick.Call();
                    break;
                }
            }
        }
    }
}