using FairyGUI;
using UnityEngine;

namespace Welfare
{
    public partial class Child_WorldBossView : GComponent
    {
        public override void OnInit()
        {
            base.OnInit();

            MenuData cfg = (MenuData)(this.data);
            Debug.LogError(cfg._name);
        }
    }
}