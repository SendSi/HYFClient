/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ServiceActivity
{
    public partial class EightDayBtn1 : GButton
    {
        public Controller _sel;
        public Controller _state;
        public Controller _number;
        public Controller _special;
        public GLoader _bg;
        public GButton _icon1;
        public GButton _icon2;
        public GButton _icon3;
        public GButton _icon4;
        public GTextField _stateTxt;
        public GTextField _stateTxt1;
        public GTextField _title1;
        public GImage _gray;
        public GGraph _mask;
        public const string URL = "ui://e290e74sfdrb1ygcfiz";

        public static EightDayBtn1 CreateInstance()
        {
            return (EightDayBtn1)UIPackage.CreateObject("ServiceActivity", "EightDayBtn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _sel = GetController("sel");
            _state = GetController("state");
            _number = GetController("number");
            _special = GetController("special");
            _bg = (GLoader)GetChild("bg");
            _icon1 = (GButton)GetChild("icon1");
            _icon2 = (GButton)GetChild("icon2");
            _icon3 = (GButton)GetChild("icon3");
            _icon4 = (GButton)GetChild("icon4");
            _stateTxt = (GTextField)GetChild("stateTxt");
            _stateTxt1 = (GTextField)GetChild("stateTxt1");
            _title1 = (GTextField)GetChild("title1");
            _gray = (GImage)GetChild("gray");
            _mask = (GGraph)GetChild("mask");
        }
    }
}