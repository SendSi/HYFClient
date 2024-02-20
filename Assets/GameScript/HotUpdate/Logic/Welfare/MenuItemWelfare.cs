using FairyGUI;

namespace Welfare
{
    public partial class MenuItemWelfare : GButton
    {
        public void SetData(MenuData cfg)//data字段不能被赋值
        {
            this.title = cfg._name;
            this._tagCtrl.selectedIndex = 0;
        }
    }
}