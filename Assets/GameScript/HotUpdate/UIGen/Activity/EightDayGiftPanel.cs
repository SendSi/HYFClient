/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class EightDayGiftPanel : GLabel
    {
        public GTextField _timeText;
        public EightDayBtn _day1;
        public EightDayBtn _day2;
        public EightDayBtn _day3;
        public EightDayBtn _day4;
        public EightDayBtn _day5;
        public EightDayBtn _day6;
        public EightDayBtn _day7;
        public EightDayBtn _day8;
        public const string URL = "ui://sinorujtzkj21ygcfj0";

        public static EightDayGiftPanel CreateInstance()
        {
            return (EightDayGiftPanel)UIPackage.CreateObject("Activity", "EightDayGiftPanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _timeText = (GTextField)GetChild("timeText");
            _day1 = (EightDayBtn)GetChild("day1");
            _day2 = (EightDayBtn)GetChild("day2");
            _day3 = (EightDayBtn)GetChild("day3");
            _day4 = (EightDayBtn)GetChild("day4");
            _day5 = (EightDayBtn)GetChild("day5");
            _day6 = (EightDayBtn)GetChild("day6");
            _day7 = (EightDayBtn)GetChild("day7");
            _day8 = (EightDayBtn)GetChild("day8");
        }
    }
}