/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ServiceActivity
{
    public partial class EightDayBtn2 : GButton
    {
        public Controller _state;
        public Controller _sel;
        public GLoader _bg;
        public GTextField _stateTxt;
        public GTextField _time;
        public GImage _gray;
        public GGraph _mask;
        public const string URL = "ui://e290e74sfdrb1ygcfj0";

        public static EightDayBtn2 CreateInstance()
        {
            return (EightDayBtn2)UIPackage.CreateObject("ServiceActivity", "EightDayBtn2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _sel = GetController("sel");
            _bg = (GLoader)GetChild("bg");
            _stateTxt = (GTextField)GetChild("stateTxt");
            _time = (GTextField)GetChild("time");
            _gray = (GImage)GetChild("gray");
            _mask = (GGraph)GetChild("mask");
        }
    }
}