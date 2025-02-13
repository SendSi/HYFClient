using FairyGUI;
using FairyGUI.Utils;
using UnityEngine;

namespace HitHamsterPKG
{
    public partial class Item_MainHamster : GComponent
    {
        public override void OnInit()
        {
            base.OnInit();
            // EventCenter.Instance.Bind();
            Debug.LogError("init gcom");
        }

        public void SetData(int cfgId)
        {
        }
        public void SetData()
        {
        }

        public override void Dispose()
        {
            base.Dispose();
            Debug.LogError("dis gcom");
        }
    }
}