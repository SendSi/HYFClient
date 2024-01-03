using System.Collections.Generic;
using CommonPKG;
using FairyGUI;
using UnityEngine;

namespace Bag
{
    public partial class BagMainView : GComponent
    {
        private List<ItemDto> mPropDtos;
        private ItemDto mSelectItemDto;
        private GList mCurrencyList_UI;
        private List<int> mCurrencyIds = new List<int>() { 1, 2, 5 };

        public override void OnInit()
        {
            base.OnInit();

            _closeButton.onClick.Set(OnClickCloseMainView);
            EventCenter.GetInstance().Bind<string>(EventEnum.EE_test, OnEventTest);

            _propList.itemRenderer = OnRenderPropList;
            _propList.onClickItem.Add(OnClickItemPropList);
            _propList.SetVirtual();
            mPropDtos = BagManager.GetInstance().GetBagViewListItem();
            if (mPropDtos.Count > 0)
            {
                _propList.numItems = mPropDtos.Count;
                _hasDataCtrl.selectedIndex = 0;
                _propList.selectedIndex = 0;
            }
            else
            {
                _hasDataCtrl.selectedIndex = 1;
            }

            mCurrencyList_UI = _currencyList.GetChild("currencyList").asList;
            mCurrencyList_UI.itemRenderer = (index, obj) =>
            {
                Item_Currency item = (Item_Currency)obj;
                item.SetData(mCurrencyIds[index]);
            };
            mCurrencyList_UI.numItems = 3;
        }

        private void OnClickItemPropList(EventContext context)
        {
            ComItem_bag item = (ComItem_bag)context.data;
            var itemDto = item.GetData();
            if (itemDto != null)
            {
                mSelectItemDto = itemDto;
                ShowRightInfo();
            }
        }

        private void OnRenderPropList(int index, GObject obj)
        {
            ComItem_bag item = (ComItem_bag)obj;
            item.SetData(mPropDtos[index]);
            if (index == 0 && mSelectItemDto != null) //首次打开页面 无值时 给其赋个值
            {
                mSelectItemDto = mPropDtos[index];
                ShowRightInfo();
            }
        }

        private void ShowRightInfo()
        {
            if (mSelectItemDto != null)
            {
                var rightIcon = (ComItem_bag)_iconProp;
                rightIcon.SetData(mSelectItemDto);
                var cfg = ConfigMgr.GetInstance().LoadConfigOne<ItemConfig>(mSelectItemDto.cfgId.ToString());
                _titlePropTxt.text = cfg.name;
                _descTxt.text = cfg.iconDesecribe;
                _hasTxt.text = mSelectItemDto.sum.ToString();
            }
        }

        private void OnEventTest(string arg0)
        {
            Debug.LogError("BagMainView 监听    EN_test_" + arg0);
        }

        private void OnClickCloseMainView()
        {
            ProxyBagModule.GetInstance().CloseBagMainView();
        }

        public void SetData()
        {
        }

        public override void Dispose()
        {
            base.Dispose();
            mSelectItemDto = null;
            mCurrencyList_UI = null;
            EventCenter.GetInstance().UnBind<string>(EventEnum.EE_test, OnEventTest);
        }
    }
}