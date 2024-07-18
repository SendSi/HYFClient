using System.Collections.Generic;
using FairyGUI;

namespace GMView
{
    public partial class GMMainView : GComponent
    {
        private List<cfg.GMConfig> _typeDtos;
        private List<cfg.GMConfig> _centerDtos;
        private List<string> _oldReDtos;
        private const string checkKey = "GMCheckCloseBtn";

        public override void OnInit()
        {
            base.OnInit();
            sortingOrder = 1000;
            this._typeList.itemRenderer = OnRendererTypeList;
            this._typeList.onClickItem.Add(OnClickItemTypeList);
            this._typeList.SetVirtual();
            _typeDtos = GMManager.Instance.GetTypeList();
            this._typeList.numItems = _typeDtos.Count;
            this._typeList.selectedIndex = 0;

            this._centerList.itemRenderer = OnRendererCenterList;
            this._centerList.onClickItem.Add(OnClickItemCenterList);
            this._centerList.SetVirtual();
            SetCenterList(1);

            this._oldReList.itemRenderer = OnRendererOldReList;
            this._oldReList.onClickItem.Add(OnClickItemOldReList);
            this._oldReList.SetVirtual();
            _oldReDtos = GMManager.Instance.GetOldReList();
            this._oldReList.numItems = _oldReDtos.Count;

            this._sendBtn.onClick.Set(OnClickSendGM);
            this._closeButton.onClick.Set(OnClickClose);

            this._checkCloseBtn.selected = PlayerPrefsHelper.GetBool(checkKey, false);
        }

        private void OnClickClose()
        {
            PlayerPrefsHelper.SetBool(checkKey, this._checkCloseBtn.selected);
            ProxyGMModule.Instance.HideGMMainView();
        }

        private void OnClickSendGM()
        {
            if (string.IsNullOrEmpty(this._inputTxt.text) == false)
            {
                GMManager.Instance.SetOldReValue(this._inputTxt.text);
                if (this._inputTxt.text.Contains("local"))
                {
                    GMManager.Instance.LocalMethodGM(this._inputTxt.text); //前端自己定义的
                }
                else
                {
                    GMManager.Instance.ServerMethodGM(this._inputTxt.text); //直接发送后端的gm
                }

                this._inputTxt.text = ""; //清空
                _oldReDtos = GMManager.Instance.GetOldReList();
                this._oldReList.numItems = _oldReDtos.Count; //重刷右边列表

                if (_checkCloseBtn.selected)
                {
                    OnClickClose();
                }
            }
        }

        private void OnClickItemOldReList(EventContext context)
        {
            var data = (GButton)context.data;
            this._descTxt.text = "";
            this._inputTxt.text = data.data.ToString();
        }

        private void OnRendererOldReList(int index, GObject item)
        {
            var str = _oldReDtos[index];
            GButton btn = (GButton)item;
            btn.title = str;
            btn.data = str;
        }

        /// <summary>中间列表  点击 </summary>
        private void OnClickItemCenterList(EventContext context)
        {
            var data = (GButton)context.data;
            var cfg = (cfg.GMConfig)data.data;
            this._descTxt.text = cfg.TDesc;
            this._inputTxt.text = cfg.TGmTxt;
        }

        /// <summary> 中间列表 渲染 </summary>
        private void OnRendererCenterList(int index, GObject item)
        {
            var dto = _centerDtos[index];
            GButton btn = (GButton)item;
            btn.title = dto.TContent;
            btn.data = dto;
        }

        /// <summary>左边列表  点击 </summary>
        private void OnClickItemTypeList(EventContext context)
        {
            var data = (GButton)context.data;
            var cfg = (cfg.GMConfig)data.data;
            SetCenterList(cfg.TType);
            _centerList.selectedIndex = -1; //左点  使右边不选中
        }

        /// <summary>左边列表  渲染 </summary>
        private void OnRendererTypeList(int index, GObject item)
        {
            var dto = _typeDtos[index];
            GButton btn = (GButton)item;
            btn.title = dto.TTypeName;
            btn.data = dto;
        }

        void SetCenterList(int tType)
        {
            _centerDtos = GMManager.Instance.GetCenterList(tType);
            _centerList.numItems = _centerDtos.Count;
        }

        public override int GetFirstChildInView()
        {
            return base.GetFirstChildInView();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}