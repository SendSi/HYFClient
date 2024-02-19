/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class ChiefView : GLabel
    {
        public Controller _state;
        public Controller _challenge;
        public GLoader _bg;
        public GLoader _bossModel;
        public GButton _closeButton;
        public GTree _list_chief;
        public GGroup _Left;
        public GTextField _timeLbl;
        public GTextField _introductiontitle;
        public GRichTextField _name;
        public GList _label_list;
        public GTextField _textPower;
        public GTextField _awardtitle;
        public GList _award_list;
        public GButton _challengeBtn;
        public GButton _gotoBtn;
        public GTextField _texttip;
        public GTextField _textnum;
        public GList _label_list2;
        public GButton _addBtn;
        public GGroup _right;
        public GList _star_list;
        public GGroup _middle;
        public Transition _t0;
        public const string URL = "ui://sinorujtw84ww";

        public static ChiefView CreateInstance()
        {
            return (ChiefView)UIPackage.CreateObject("Activity", "ChiefView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _challenge = GetController("challenge");
            _bg = (GLoader)GetChild("bg");
            _bossModel = (GLoader)GetChild("bossModel");
            _closeButton = (GButton)GetChild("closeButton");
            _list_chief = (GTree)GetChild("list_chief");
            _Left = (GGroup)GetChild("Left");
            _timeLbl = (GTextField)GetChild("timeLbl");
            _introductiontitle = (GTextField)GetChild("introductiontitle");
            _name = (GRichTextField)GetChild("name");
            _label_list = (GList)GetChild("label_list");
            _textPower = (GTextField)GetChild("textPower");
            _awardtitle = (GTextField)GetChild("awardtitle");
            _award_list = (GList)GetChild("award_list");
            _challengeBtn = (GButton)GetChild("challengeBtn");
            _gotoBtn = (GButton)GetChild("gotoBtn");
            _texttip = (GTextField)GetChild("texttip");
            _textnum = (GTextField)GetChild("textnum");
            _label_list2 = (GList)GetChild("label_list2");
            _addBtn = (GButton)GetChild("addBtn");
            _right = (GGroup)GetChild("right");
            _star_list = (GList)GetChild("star_list");
            _middle = (GGroup)GetChild("middle");
            _t0 = GetTransition("t0");
        }
    }
}