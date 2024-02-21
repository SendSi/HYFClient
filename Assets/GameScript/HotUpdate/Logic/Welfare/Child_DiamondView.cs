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

            this._diamondList.itemRenderer = OnRendererDiamond;
            this._diamondList.numItems = 6;
            
            this._goWarBtn.onClick.Set(OnClickGoWarBtn);
            this._curProSlider.max = 250;
            this._curProSlider.value = 120;
        }

        private void OnClickGoWarBtn()
        {
            Debug.LogError("前往战令");
        }

        private void OnRendererDiamond(int index, GObject item)
        {
            DiamondItem obj = (DiamondItem)item;
            obj.SetData();
        }
    }
}