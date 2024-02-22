using FairyGUI;
using UnityEngine;

namespace Welfare
{
    public partial class Child_WishView : GComponent
    {
        public override void OnInit()
        {
            base.OnInit();

            WelfareMenuConfig cfg = (WelfareMenuConfig)(this.data);
            Debug.LogError(cfg.name);
        }
    }
}