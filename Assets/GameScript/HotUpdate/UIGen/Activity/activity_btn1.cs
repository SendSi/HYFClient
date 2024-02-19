/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class activity_btn1 : GButton
    {
        public Controller _state;
        public GLoader _bg;
        public GTextField _stateTxt;
        public GTextField _ongoing;
        public const string URL = "ui://sinorujty6ps1ygcflq";

        public static activity_btn1 CreateInstance()
        {
            return (activity_btn1)UIPackage.CreateObject("Activity", "activity_btn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _bg = (GLoader)GetChild("bg");
            _stateTxt = (GTextField)GetChild("stateTxt");
            _ongoing = (GTextField)GetChild("ongoing");
        }
    }
}