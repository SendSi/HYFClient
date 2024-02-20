using FairyGUI;
using UnityEngine;

namespace Welfare
{
    public partial class WelfareMainView : GComponent
    {
        public override void OnInit()
        {
            base.OnInit();

            this._closeButton.onClick.Set(() => { ProxyWelfareModule.Instance.CloseWelfareMainView(); });

            this._leftTabList.itemRenderer = OnRendererTabList;
            this._leftTabList.itemProvider = OnProviderTabList;

        }

        private string OnProviderTabList(int index)
        {
            return "MenuItemWelfare";
            return "MenuTypeWelfare";
        }

        private void OnRendererTabList(int index, GObject item)
        {
            
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        public void SetData(string value)
        {
            Debug.LogError("TTTT");
        }
    }
}