using System;
using FairyGUI;

namespace Welfare
{
    public partial class DiamondItem:GButton
    {
        public void SetData()
        {
            var value = UnityEngine.Random.Range(100, 200);
            this._numLbl.text = value.ToString();
            this._rmbLbl.text = (value * 0.1).ToString();
        }
    }
}