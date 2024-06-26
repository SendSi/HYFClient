﻿using System.Collections.Generic;
using CommonPKG;
using FairyGUI;
using UnityEngine;
using HYFServer;

namespace Bag
{
    public partial class BagMainView : GComponent
    {
        private List<ItemDto> mPropDtos;
        private ItemDto mSelectItemDto;
        private List<int> mCurrencyIds = new List<int>() { 1, 2, 5 };

        public override void OnInit()
        {
            base.OnInit();

            _closeButton.onClick.Set(OnClickCloseMainView);
            EventCenter.Instance.Bind<string>(EventEnum.EE_test, OnEventTest);

            _propList.itemRenderer = OnRenderPropList;
            _propList.onClickItem.Add(OnClickItemPropList);
            _propList.SetVirtual();
            mPropDtos = BagManager.Instance.GetBagViewListItem();
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

            CurrencyListCom currencyListCom = (CurrencyListCom)_currencyList;
            currencyListCom.SetData(mCurrencyIds);

            _btnCanUsing.onClick.Set(OnClickUsing);

            RedPoint redAll = (RedPoint)_tab01.GetChild("redPoint");
            redAll.SetData(RedDotDefine.Bag_all);

            RedPoint redRes = (RedPoint)_tab02.GetChild("redPoint");
            redRes.SetData(RedDotDefine.Bag_res);

            RedPoint redEqu = (RedPoint)_tab03.GetChild("redPoint");
            redEqu.SetData(RedDotDefine.Bag_equ);

            _tabCtrl.onChanged.Add(OnLeftTabChaged);
        }

        private void OnLeftTabChaged()
        {
            var sIndex = _tabCtrl.selectedIndex;
            BagManager.Instance.BagTabReadIndex(sIndex);
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
            if (index == 0 && mSelectItemDto == null) //首次打开页面 无值时 给其赋个值
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
                var cfg = ConfigMgr.Instance.LoadConfigOne<ItemConfig>(mSelectItemDto.CfgId.ToString());
                _titlePropTxt.text = cfg.name;
                _descTxt.text = cfg.iconDesecribe;
                _hasTxt.text = mSelectItemDto.Sum.ToString();
            }
        }

        private void OnEventTest(string arg0)
        {
            Debug.LogError("BagMainView 监听    EN_test_" + arg0);
        }

        private void OnClickCloseMainView()
        {
            ProxyBagModule.Instance.CloseBagMainView();
        }

        public void SetData()
        {
        }

        public override void Dispose()
        {
            mSelectItemDto = null;
            EventCenter.Instance.UnBind<string>(EventEnum.EE_test, OnEventTest);
            base.Dispose();
        }

        private async void OnClickUsing()
        {
            var result = await ProtocalBag.Instance.BagUsingItem(1, 1);
            Debug.LogError(result);
        }
    }
}