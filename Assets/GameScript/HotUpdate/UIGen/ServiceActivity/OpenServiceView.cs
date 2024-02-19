/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ServiceActivity
{
    public partial class OpenServiceView : GLabel
    {
        public Controller _state;
        public Controller _modal;
        public Controller _state001;
        public GLoader _bg;
        public GTextField _describeLbl_01;
        public GTextField _describeLbl_02;
        public GTextField _timeText;
        public GButton _gotoBtn;
        public GTextField _rankLbl;
        public GTextField _nameLbl;
        public GTextField _gradeLbl;
        public GTextField _awardLbl;
        public GList _rankList;
        public GTextField _myGradeLbl;
        public GTextField _myGradeText;
        public GTextField _myRankLbl;
        public GTextField _myRankText;
        public GButton _previewBtn;
        public GLoader _bg02;
        public GLoader _bg01;
        public GList _day;
        public GTextField _Lbl01;
        public GGraph _modal_2;
        public GTextField _modalLbl;
        public GButton _bossBtn;
        public GTextField _tipText;
        public GGroup _window;
        public const string URL = "ui://e290e74se8ok1ygcfpg";

        public static OpenServiceView CreateInstance()
        {
            return (OpenServiceView)UIPackage.CreateObject("ServiceActivity", "OpenServiceView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _modal = GetController("modal");
            _state001 = GetController("state001");
            _bg = (GLoader)GetChild("bg");
            _describeLbl_01 = (GTextField)GetChild("describeLbl_01");
            _describeLbl_02 = (GTextField)GetChild("describeLbl_02");
            _timeText = (GTextField)GetChild("timeText");
            _gotoBtn = (GButton)GetChild("gotoBtn");
            _rankLbl = (GTextField)GetChild("rankLbl");
            _nameLbl = (GTextField)GetChild("nameLbl");
            _gradeLbl = (GTextField)GetChild("gradeLbl");
            _awardLbl = (GTextField)GetChild("awardLbl");
            _rankList = (GList)GetChild("rankList");
            _myGradeLbl = (GTextField)GetChild("myGradeLbl");
            _myGradeText = (GTextField)GetChild("myGradeText");
            _myRankLbl = (GTextField)GetChild("myRankLbl");
            _myRankText = (GTextField)GetChild("myRankText");
            _previewBtn = (GButton)GetChild("previewBtn");
            _bg02 = (GLoader)GetChild("bg02");
            _bg01 = (GLoader)GetChild("bg01");
            _day = (GList)GetChild("day");
            _Lbl01 = (GTextField)GetChild("Lbl01");
            _modal_2 = (GGraph)GetChild("modal");
            _modalLbl = (GTextField)GetChild("modalLbl");
            _bossBtn = (GButton)GetChild("bossBtn");
            _tipText = (GTextField)GetChild("tipText");
            _window = (GGroup)GetChild("window");
        }
    }
}