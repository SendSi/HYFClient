using FairyGUI;
using UnityEngine;

namespace Welfare
{
    public partial class Child_DiamondView : GComponent
    {
        public override void OnInit()
        {
            base.OnInit();

            MenuData cfg = (MenuData)(this.data);
            Debug.LogError(cfg._name);
        }
    }
}