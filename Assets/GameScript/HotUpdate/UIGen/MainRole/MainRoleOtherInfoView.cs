/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainRole
{
    public partial class MainRoleOtherInfoView : GLabel
    {
        public GButton _win;
        public GTree _item;
        public GTextField _nameLbl;
        public GTextField _combatEffectivenessLbl;
        public GGroup _view;
        public const string URL = "ui://66sh7tc6dnyfhz9czi";

        public static MainRoleOtherInfoView CreateInstance()
        {
            return (MainRoleOtherInfoView)UIPackage.CreateObject("MainRole", "MainRoleOtherInfoView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _win = (GButton)GetChild("win");
            _item = (GTree)GetChild("item");
            _nameLbl = (GTextField)GetChild("nameLbl");
            _combatEffectivenessLbl = (GTextField)GetChild("combatEffectivenessLbl");
            _view = (GGroup)GetChild("view");
        }
    }
}