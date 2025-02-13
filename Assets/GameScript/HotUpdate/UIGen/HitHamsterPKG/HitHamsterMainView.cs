/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace HitHamsterPKG
{
    public partial class HitHamsterMainView : GComponent
    {
        public Controller _stateCtrl;
        public Controller _timeCtrl;
        public GImage _bg;
        public GList _hamsterList;
        public GGraph _bigMarkBtn;
        public GTextField _startTxt;
        public GTextField _titleTxt;
        public GTextField _gameOverTxt;
        public GGroup _stateSwitch;
        public GGraph _maskNum;
        public GRichTextField _startOneTxt;
        public GGroup _startNumFather;
        public GList _hpList;
        public GButton _stopBtn;
        public sliderBar _timeBar;
        public GImage _img;
        public GTextField _timeTxt;
        public GTextField _scoreTxt;
        public GGroup _timeGroup;
        public GButton _continueBtn;
        public GButton _closeButton;
        public Transition _boom;
        public Transition _t1;
        public const string URL = "ui://q0kdbd65ntf2eae";

        public static HitHamsterMainView CreateInstance()
        {
            return (HitHamsterMainView)UIPackage.CreateObject("HitHamsterPKG", "HitHamsterMainView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _stateCtrl = GetController("stateCtrl");
            _timeCtrl = GetController("timeCtrl");
            _bg = (GImage)GetChild("bg");
            _hamsterList = (GList)GetChild("hamsterList");
            _bigMarkBtn = (GGraph)GetChild("bigMarkBtn");
            _startTxt = (GTextField)GetChild("startTxt");
            _titleTxt = (GTextField)GetChild("titleTxt");
            _gameOverTxt = (GTextField)GetChild("gameOverTxt");
            _stateSwitch = (GGroup)GetChild("stateSwitch");
            _maskNum = (GGraph)GetChild("maskNum");
            _startOneTxt = (GRichTextField)GetChild("startOneTxt");
            _startNumFather = (GGroup)GetChild("startNumFather");
            _hpList = (GList)GetChild("hpList");
            _stopBtn = (GButton)GetChild("stopBtn");
            _timeBar = (sliderBar)GetChild("timeBar");
            _img = (GImage)GetChild("img");
            _timeTxt = (GTextField)GetChild("timeTxt");
            _scoreTxt = (GTextField)GetChild("scoreTxt");
            _timeGroup = (GGroup)GetChild("timeGroup");
            _continueBtn = (GButton)GetChild("continueBtn");
            _closeButton = (GButton)GetChild("closeButton");
            _boom = GetTransition("boom");
            _t1 = GetTransition("t1");
        }
    }
}