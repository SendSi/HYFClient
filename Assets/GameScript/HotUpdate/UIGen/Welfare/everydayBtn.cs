/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class everydayBtn : GButton
    {
        public Controller _state;
        public GButton _propBtn;
        public GTextField _stateLbl;
        public Transition _scale;
        public const string URL = "ui://340eighfrs9w1ygcfmu";

        public static everydayBtn CreateInstance()
        {
            return (everydayBtn)UIPackage.CreateObject("Welfare", "everydayBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _propBtn = (GButton)GetChild("propBtn");
            _stateLbl = (GTextField)GetChild("stateLbl");
            _scale = GetTransition("scale");
        }
    }
}