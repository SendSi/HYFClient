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

        public MenuData(int id, string name, int type)
        {
            this._id = id;
            this._name = name;
            this._type = type;
        }
    }

    public partial class WelfareMainView : GComponent
    {
        private List<MenuData> mMenuDtos= new List<MenuData>()
        {
            new MenuData(1000,"新手活动",0),
            new MenuData(1001,"成长基金",1),
            new MenuData(1002,"首充礼包",1),
            new MenuData(2000,"日常活动",0),
            new MenuData(2001,"每日特惠",1),
            new MenuData(2002,"每周特惠",1),
        };
        public override void OnInit()
        {
            base.OnInit();

           
            this._closeButton.onClick.Set(() => { ProxyWelfareModule.Instance.CloseWelfareMainView(); });

            this._leftTabList.itemRenderer = OnRendererTabList;
            this._leftTabList.itemProvider = OnProviderTabList;
            this._leftTabList.onClickItem.Add(OnClickItemLeftTab);
        }

        private void OnClickItemLeftTab()
        {
        }

        private string OnProviderTabList(int index)
        {
            return  mMenuDtos[index]._type==0?"MenuTypeWelfare":"MenuItemWelfare";
        }

        private void OnRendererTabList(int index, GObject obj)
        {
            var cfg = mMenuDtos[index];
            if (cfg._type==0)
            {
                MenuTypeWelfare item = (MenuTypeWelfare)obj;
                item.SetData(mMenuDtos[index]);
            }
            else
            {
                MenuItemWelfare item = (MenuItemWelfare)obj;
                item.SetData(mMenuDtos[index]);
            }

            obj.data = cfg;
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        public void SetData(string value)
        {
            Debug.LogError("TTTT");
            this._leftTabList.numItems = 6;// mMenuDtos.Count;
        }
    }
}