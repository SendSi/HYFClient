/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class CheckInItem : GButton
    {
        public Controller _stateCtrl;
        public GLoader _bgIcon;
        public GButton _propBtn;
        public GTextField _stateLbl;
        public Transition _scale;
        public const string URL = "ui://340eighfrs9w1ygcfmu";

        public static CheckInItem CreateInstance()
        {
            return (CheckInItem)UIPackage.CreateObject("Welfare", "CheckInItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _stateCtrl = GetController("stateCtrl");
            _bgIcon = (GLoader)GetChild("bgIcon");
            _propBtn = (GButton)GetChild("propBtn");
            _stateLbl = (GTextField)GetChild("stateLbl");
            _scale = GetTransition("scale");
        }
    }
}