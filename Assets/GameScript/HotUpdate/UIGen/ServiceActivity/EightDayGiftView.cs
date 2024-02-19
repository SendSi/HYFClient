/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ServiceActivity
{
    public partial class EightDayGiftView : GLabel
    {
        public GLoader _bg;
        public EightDayBtn1 _day1;
        public EightDayBtn1 _day2;
        public EightDayBtn1 _day3;
        public EightDayBtn1 _day4;
        public EightDayBtn1 _day5;
        public EightDayBtn1 _day6;
        public EightDayBtn1 _day7;
        public EightDayBtn2 _day8;
        public GTextField _title1;
        public GTextField _timeText;
        public GGroup _window;
        public Transition _t0;
        public const string URL = "ui://e290e74se8ok1ygcfpf";

        public static EightDayGiftView CreateInstance()
        {
            return (EightDayGiftView)UIPackage.CreateObject("ServiceActivity", "EightDayGiftView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GLoader)GetChild("bg");
            _day1 = (EightDayBtn1)GetChild("day1");
            _day2 = (EightDayBtn1)GetChild("day2");
            _day3 = (EightDayBtn1)GetChild("day3");
            _day4 = (EightDayBtn1)GetChild("day4");
            _day5 = (EightDayBtn1)GetChild("day5");
            _day6 = (EightDayBtn1)GetChild("day6");
            _day7 = (EightDayBtn1)GetChild("day7");
            _day8 = (EightDayBtn2)GetChild("day8");
            _title1 = (GTextField)GetChild("title1");
            _timeText = (GTextField)GetChild("timeText");
            _window = (GGroup)GetChild("window");
            _t0 = GetTransition("t0");
        }
    }
}