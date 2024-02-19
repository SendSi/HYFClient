/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class ActivityView : GLabel
    {
        public Controller _tab;
        public Controller _state01;
        public Controller _state02;
        public Controller _week;
        public Controller _requesting;
        public GLoader _bg;
        public GTextField _Monday;
        public GTextField _Tuesday;
        public GTextField _Wednesday;
        public GTextField _Thursday;
        public GTextField _Friday;
        public GTextField _Saturday;
        public GTextField _Sunday;
        public GTextField _title_date01;
        public GTextField _title_date02;
        public GTextField _title_date03;
        public GTextField _title_date04;
        public GTextField _title_date05;
        public GTextField _title_date06;
        public GTextField _title_date07;
        public GList _list01;
        public GGroup _calendar;
        public ActPanel _panel;
        public GList _list;
        public GButton _illustrationBtn;
        public recoverBtn _recoverBtn;
        public GButton _closeButton;
        public GGroup _activity;
        public actBtn _actBtn;
        public const string URL = "ui://sinorujtw84wn";

        public static ActivityView CreateInstance()
        {
            return (ActivityView)UIPackage.CreateObject("Activity", "ActivityView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _tab = GetController("tab");
            _state01 = GetController("state01");
            _state02 = GetController("state02");
            _week = GetController("week");
            _requesting = GetController("requesting");
            _bg = (GLoader)GetChild("bg");
            _Monday = (GTextField)GetChild("Monday");
            _Tuesday = (GTextField)GetChild("Tuesday");
            _Wednesday = (GTextField)GetChild("Wednesday");
            _Thursday = (GTextField)GetChild("Thursday");
            _Friday = (GTextField)GetChild("Friday");
            _Saturday = (GTextField)GetChild("Saturday");
            _Sunday = (GTextField)GetChild("Sunday");
            _title_date01 = (GTextField)GetChild("title_date01");
            _title_date02 = (GTextField)GetChild("title_date02");
            _title_date03 = (GTextField)GetChild("title_date03");
            _title_date04 = (GTextField)GetChild("title_date04");
            _title_date05 = (GTextField)GetChild("title_date05");
            _title_date06 = (GTextField)GetChild("title_date06");
            _title_date07 = (GTextField)GetChild("title_date07");
            _list01 = (GList)GetChild("list01");
            _calendar = (GGroup)GetChild("calendar");
            _panel = (ActPanel)GetChild("panel");
            _list = (GList)GetChild("list");
            _illustrationBtn = (GButton)GetChild("illustrationBtn");
            _recoverBtn = (recoverBtn)GetChild("recoverBtn");
            _closeButton = (GButton)GetChild("closeButton");
            _activity = (GGroup)GetChild("activity");
            _actBtn = (actBtn)GetChild("actBtn");
        }
    }
}