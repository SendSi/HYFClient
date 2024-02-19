/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class WorldLeaderView : GLabel
    {
        public Controller _plus;
        public Controller _challenge;
        public GLoader _bg;
        public GLoader _bossModel;
        public GButton _closeButton;
        public GTree _list_chief;
        public GGroup _Left;
        public GTextField _time;
        public GGroup _middle;
        public GTextField _timeLbl;
        public GTextField _introductiontitle;
        public GRichTextField _name;
        public GList _label_list;
        public GTextField _textPower;
        public GTextField _txtbelong;
        public GImage _bg1;
        public GButton _head;
        public GTextField _playerName;
        public GTextField _awardtitle;
        public GList _award_list;
        public GButton _challengeBtn;
        public GTextField _textnum;
        public GList _label_list2;
        public GButton _addBtn;
        public GGroup _right;
        public Transition _t0;
        public Transition _toggle;
        public const string URL = "ui://sinorujtha7x1r";

        public static WorldLeaderView CreateInstance()
        {
            return (WorldLeaderView)UIPackage.CreateObject("Activity", "WorldLeaderView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _plus = GetController("plus");
            _challenge = GetController("challenge");
            _bg = (GLoader)GetChild("bg");
            _bossModel = (GLoader)GetChild("bossModel");
            _closeButton = (GButton)GetChild("closeButton");
            _list_chief = (GTree)GetChild("list_chief");
            _Left = (GGroup)GetChild("Left");
            _time = (GTextField)GetChild("time");
            _middle = (GGroup)GetChild("middle");
            _timeLbl = (GTextField)GetChild("timeLbl");
            _introductiontitle = (GTextField)GetChild("introductiontitle");
            _name = (GRichTextField)GetChild("name");
            _label_list = (GList)GetChild("label_list");
            _textPower = (GTextField)GetChild("textPower");
            _txtbelong = (GTextField)GetChild("txtbelong");
            _bg1 = (GImage)GetChild("bg1");
            _head = (GButton)GetChild("head");
            _playerName = (GTextField)GetChild("playerName");
            _awardtitle = (GTextField)GetChild("awardtitle");
            _award_list = (GList)GetChild("award_list");
            _challengeBtn = (GButton)GetChild("challengeBtn");
            _textnum = (GTextField)GetChild("textnum");
            _label_list2 = (GList)GetChild("label_list2");
            _addBtn = (GButton)GetChild("addBtn");
            _right = (GGroup)GetChild("right");
            _t0 = GetTransition("t0");
            _toggle = GetTransition("toggle");
        }
    }
}