using FairyGUI;

namespace Welfare
{
    public partial class CheckInItem : GButton
    {
        public void SetData(int dayNum)
        {
            this.title = $"第{dayNum}天";
            this._stateCtrl.selectedIndex = 0;
        }
    }
}