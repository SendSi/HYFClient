/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class OpenServicePanel : GLabel
    {
        public Controller _state;
        public Controller _onRank;
        public Controller _popup;
        public GLoader _bg;
        public GList _rewardList;
        public OpenServiceBtn _day1;
        public OpenServiceBtn _day2;
        public OpenServiceBtn _day3;
        public OpenServiceBtn _day4;
        public OpenServiceBtn _day5;
        public OpenServiceBtn _day6;
        public OpenServiceBtn _day7;
        public GLoader _bg01;
        public GButton _btnNext;
        public GTextField _describeLbl_01;
        public GTextField _describeLbl_02;
        public GTextField _dayLbl;
        public GTextField _timeLbl;
        public GTextField _RankingLbl;
        public GTextField _nameLbl;
        public GTextField _noRankLbl;
        public GTextField _GradeLbl;
        public GButton _rewardBtn;
        public GButton _gotoBtn;
        public const string URL = "ui://sinorujtcsb41ygcfht";

        public static OpenServicePanel CreateInstance()
        {
            return (OpenServicePanel)UIPackage.CreateObject("Activity", "OpenServicePanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _onRank = GetController("onRank");
            _popup = GetController("popup");
            _bg = (GLoader)GetChild("bg");
            _rewardList = (GList)GetChild("rewardList");
            _day1 = (OpenServiceBtn)GetChild("day1");
            _day2 = (OpenServiceBtn)GetChild("day2");
            _day3 = (OpenServiceBtn)GetChild("day3");
            _day4 = (OpenServiceBtn)GetChild("day4");
            _day5 = (OpenServiceBtn)GetChild("day5");
            _day6 = (OpenServiceBtn)GetChild("day6");
            _day7 = (OpenServiceBtn)GetChild("day7");
            _bg01 = (GLoader)GetChild("bg01");
            _btnNext = (GButton)GetChild("btnNext");
            _describeLbl_01 = (GTextField)GetChild("describeLbl_01");
            _describeLbl_02 = (GTextField)GetChild("describeLbl_02");
            _dayLbl = (GTextField)GetChild("dayLbl");
            _timeLbl = (GTextField)GetChild("timeLbl");
            _RankingLbl = (GTextField)GetChild("RankingLbl");
            _nameLbl = (GTextField)GetChild("nameLbl");
            _noRankLbl = (GTextField)GetChild("noRankLbl");
            _GradeLbl = (GTextField)GetChild("GradeLbl");
            _rewardBtn = (GButton)GetChild("rewardBtn");
            _gotoBtn = (GButton)GetChild("gotoBtn");
        }
    }
}