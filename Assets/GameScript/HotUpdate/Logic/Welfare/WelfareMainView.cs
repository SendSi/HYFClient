using FairyGUI;
using UnityEngine;

namespace Welfare
{
    public partial class WelfareMainView : GComponent
    {
        public override void OnInit()
        {
            base.OnInit();
            Debug.LogError("onInit");
            this._closeButton.onClick.Set(() =>
            {
                ProxyWelfareModule.Instance.CloseWelfareMainView();
            });
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