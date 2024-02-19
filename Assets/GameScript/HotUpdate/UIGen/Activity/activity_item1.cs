/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class activity_item1 : GButton
    {
        public Controller _state;
        public Controller _planned;
        public Controller _style;
        public GLoader _bg;
        public GImage _customsbg;
        public GTextField _stateTxt;
        public GTextField _ongoing;
        public GGraph _clickMask;
        public const string URL = "ui://sinorujtp9k91ygcfjg";

        public static activity_item1 CreateInstance()
        {
            return (activity_item1)UIPackage.CreateObject("Activity", "activity_item1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _planned = GetController("planned");
            _style = GetController("style");
            _bg = (GLoader)GetChild("bg");
            _customsbg = (GImage)GetChild("customsbg");
            _stateTxt = (GTextField)GetChild("stateTxt");
            _ongoing = (GTextField)GetChild("ongoing");
            _clickMask = (GGraph)GetChild("clickMask");
        }
    }
}