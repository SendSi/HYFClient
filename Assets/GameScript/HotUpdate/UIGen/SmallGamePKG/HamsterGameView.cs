/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SmallGamePKG
{
    public partial class HamsterGameView : GComponent
    {
        public Controller _stateCtrl;
        public Controller _timeCtrl;
        public GLoader _bg;
        public GList _hamsterList;
        public GGraph _bigBgMark;
        public GTextField _startTxt;
        public GTextField _titleTxt;
        public GTextField _gameOverTxt;
        public GGroup _stateSwitch;
        public GGraph _mask;
        public GRichTextField _startOneTxt;
        public GGroup _startNumFather;
        public GTextField _scoreTxt;
        public GTextField _lbl;
        public GGroup _scoreGroup;
        public GList _hpList;
        public GButton _stopBtn;
        public sliderBar _timeBar;
        public GImage _img;
        public GTextField _timeTxt;
        public GGroup _timeGroup;
        public GButton _continueBtn;
        public Transition _boom;
        public Transition _t1;
        public const string URL = "ui://q0kdbd65ntf2eae";

        public static HamsterGameView CreateInstance()
        {
            return (HamsterGameView)UIPackage.CreateObject("SmallGamePKG", "HamsterGameView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _stateCtrl = GetController("stateCtrl");
            _timeCtrl = GetController("timeCtrl");
            _bg = (GLoader)GetChild("bg");
            _hamsterList = (GList)GetChild("hamsterList");
            _bigBgMark = (GGraph)GetChild("bigBgMark");
            _startTxt = (GTextField)GetChild("startTxt");
            _titleTxt = (GTextField)GetChild("titleTxt");
            _gameOverTxt = (GTextField)GetChild("gameOverTxt");
            _stateSwitch = (GGroup)GetChild("stateSwitch");
            _mask = (GGraph)GetChild("mask");
            _startOneTxt = (GRichTextField)GetChild("startOneTxt");
            _startNumFather = (GGroup)GetChild("startNumFather");
            _scoreTxt = (GTextField)GetChild("scoreTxt");
            _lbl = (GTextField)GetChild("lbl");
            _scoreGroup = (GGroup)GetChild("scoreGroup");
            _hpList = (GList)GetChild("hpList");
            _stopBtn = (GButton)GetChild("stopBtn");
            _timeBar = (sliderBar)GetChild("timeBar");
            _img = (GImage)GetChild("img");
            _timeTxt = (GTextField)GetChild("timeTxt");
            _timeGroup = (GGroup)GetChild("timeGroup");
            _continueBtn = (GButton)GetChild("continueBtn");
            _boom = GetTransition("boom");
            _t1 = GetTransition("t1");
        }
    }
}