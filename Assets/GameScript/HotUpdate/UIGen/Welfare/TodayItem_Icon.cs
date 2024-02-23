/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class TodayItem_Icon : GButton
    {
        public Controller _stateCtrl;
        public GLoader _iconOpen;
        public Transition _open;
        public const string URL = "ui://340eighfhsk61ygcflq";

        public static TodayItem_Icon CreateInstance()
        {
            return (TodayItem_Icon)UIPackage.CreateObject("Welfare", "TodayItem_Icon");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _stateCtrl = GetController("stateCtrl");
            _iconOpen = (GLoader)GetChild("iconOpen");
            _open = GetTransition("open");
        }
    }
}