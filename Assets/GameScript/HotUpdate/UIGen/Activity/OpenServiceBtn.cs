/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class OpenServiceBtn : GButton
    {
        public Controller _state;
        public GButton _propBtn;
        public const string URL = "ui://sinorujtewrz1ygcfhu";

        public static OpenServiceBtn CreateInstance()
        {
            return (OpenServiceBtn)UIPackage.CreateObject("Activity", "OpenServiceBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _propBtn = (GButton)GetChild("propBtn");
        }
    }
}