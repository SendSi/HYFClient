using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

namespace GMView
{
    public partial class GMMainView : GComponent
    {
        private List<GMConfig> typeDtos;
        private GButton typeBtn;

        private List<GMConfig> centerDtos;
        private GButton centerBtn;

        public override void OnInit()
        {
            base.OnInit();
            this._typeList.itemRenderer = OnRendererTypeList;
            this._typeList.onClickItem.Add(OnClickItemTypeList);
            this._typeList.SetVirtual();
            typeDtos = GMManager.Instance.GetTypeList();
            this._typeList.numItems = typeDtos.Count;

            this._centerList.itemRenderer = OnRendererCenterList;
            this._centerList.onClickItem.Add(OnClickItemCenterList);
            this._centerList.SetVirtual();

            this._oldReList.itemRenderer = OnRendererOldReList;
            this._oldReList.onClickItem.Add(OnClickItemOldReList);
            this._oldReList.SetVirtual();
        }

        private void OnClickItemOldReList(EventContext context)
        {
        }

        private void OnRendererOldReList(int index, GObject item)
        {
        }

        private void OnClickItemCenterList(EventContext context)
        {
        }

        private void OnRendererCenterList(int index, GObject item)
        {
            var dto = centerDtos[index];
            GButton btn = (GButton)item;
            btn.title = dto.tContent;
            btn.data = dto;
        }

        private void OnClickItemTypeList(EventContext context)
        {
            var data = context.data;
            Debug.LogError(data);
        }

        private void OnRendererTypeList(int index, GObject item)
        {
            var dto = typeDtos[index];
            GButton btn = (GButton)item;
            btn.title = dto.tTypeName;
            btn.data = dto;
            if (typeBtn == null)
            {
                typeBtn = btn;
                _typeList.selectedIndex = 0;
                centerDtos = GMManager.Instance.GetCenterList(dto.tType);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}