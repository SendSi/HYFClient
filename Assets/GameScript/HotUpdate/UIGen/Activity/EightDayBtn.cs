/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class EightDayBtn : GButton
    {
        public Controller _state;
        public GButton _propBtn;
        public GTextField _stateLbl;
        public const string URL = "ui://sinorujtefo21ygcfit";

        public static EightDayBtn CreateInstance()
        {
            return (EightDayBtn)UIPackage.CreateObject("Activity", "EightDayBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _propBtn = (GButton)GetChild("propBtn");
            _stateLbl = (GTextField)GetChild("stateLbl");
        }
    }
}