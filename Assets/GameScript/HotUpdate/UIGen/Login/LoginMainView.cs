/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
    public partial class LoginMainView : GComponent
    {
        public GLoader _bg0;
        public GButton _noticeBtn;
        public GButton _accountBtn;
        public GButton _cfgBtn;
        public GButton _serviceBtn;
        public GButton _effectBtn;
        public GButton _stopBtn;
        public GButton _testBtn;
        public GGroup _left;
        public GTextField _title_version;
        public GButton _ageBtn;
        public GButton _loginBtn;
        public GImage _inputBg;
        public GTextField _lbl;
        public GTextInput _roleInputTxt;
        public GGroup _info;
        public GTextField _title_03;
        public GTextField _title_04;
        public GComboBox _languCom;
        public Transition _tMove0;
        public Transition _tMove1;
        public Transition _tMove2;
        public const string URL = "ui://byy9k3gh7oize";

        public static LoginMainView CreateInstance()
        {
            return (LoginMainView)UIPackage.CreateObject("Login", "LoginMainView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg0 = (GLoader)GetChild("bg0");
            _noticeBtn = (GButton)GetChild("noticeBtn");
            _accountBtn = (GButton)GetChild("accountBtn");
            _cfgBtn = (GButton)GetChild("cfgBtn");
            _serviceBtn = (GButton)GetChild("serviceBtn");
            _effectBtn = (GButton)GetChild("effectBtn");
            _stopBtn = (GButton)GetChild("stopBtn");
            _testBtn = (GButton)GetChild("testBtn");
            _left = (GGroup)GetChild("left");
            _title_version = (GTextField)GetChild("title_version");
            _ageBtn = (GButton)GetChild("ageBtn");
            _loginBtn = (GButton)GetChild("loginBtn");
            _inputBg = (GImage)GetChild("inputBg");
            _lbl = (GTextField)GetChild("lbl");
            _roleInputTxt = (GTextInput)GetChild("roleInputTxt");
            _info = (GGroup)GetChild("info");
            _title_03 = (GTextField)GetChild("title_03");
            _title_04 = (GTextField)GetChild("title_04");
            _languCom = (GComboBox)GetChild("languCom");
            _tMove0 = GetTransition("tMove0");
            _tMove1 = GetTransition("tMove1");
            _tMove2 = GetTransition("tMove2");
        }
    }
}