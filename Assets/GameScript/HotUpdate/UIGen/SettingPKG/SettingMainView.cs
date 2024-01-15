/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SettingPKG
{
    public partial class SettingMainView : GComponent
    {
        public Controller _stateCtrl;
        public GLabel _frame;
        public GButton _tab01;
        public GButton _tab02;
        public GTextField _title_advanced;
        public GTextField _music;
        public settingSwitchBtn1 _musicSwitch;
        public GTextField _sound;
        public settingSwitchBtn1 _voiceSwitch;
        public GTextField _musicvol;
        public GTextField _soundvol;
        public GSlider _bgmSbr;
        public GSlider _musicSbr;
        public GTextField _title_voice;
        public GTextField _visual;
        public settingSel0 _pictureBtn1;
        public GTextField _frameTxt;
        public settingSel1 _framesBtn1;
        public GTextField _shielding;
        public GTextField _hurtText;
        public settingSwitchBtn1 _effectsSwitch;
        public settingSwitchBtn1 _hurtTextSwitch;
        public GTextField _troopNumText;
        public settingSel0 _troopNumBtn;
        public GGroup _tab1;
        public GButton _playerIcon;
        public GTextField _playerName;
        public GTextField _serverName;
        public GButton _announcementBtn;
        public GButton _customerServiceBtn;
        public GButton _switchSccountsBtn;
        public GGroup _bottom;
        public GGroup _setting;
        public GButton _addCopyBtn;
        public GButton _awardBtn;
        public GTextInput _inputCodeTxt;
        public GButton _txtCopyBtn;
        public GGroup _gift;
        public const string URL = "ui://dh3hukhzg30w1";

        public static SettingMainView CreateInstance()
        {
            return (SettingMainView)UIPackage.CreateObject("SettingPKG", "SettingMainView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _stateCtrl = GetController("stateCtrl");
            _frame = (GLabel)GetChild("frame");
            _tab01 = (GButton)GetChild("tab01");
            _tab02 = (GButton)GetChild("tab02");
            _title_advanced = (GTextField)GetChild("title_advanced");
            _music = (GTextField)GetChild("music");
            _musicSwitch = (settingSwitchBtn1)GetChild("musicSwitch");
            _sound = (GTextField)GetChild("sound");
            _voiceSwitch = (settingSwitchBtn1)GetChild("voiceSwitch");
            _musicvol = (GTextField)GetChild("musicvol");
            _soundvol = (GTextField)GetChild("soundvol");
            _bgmSbr = (GSlider)GetChild("bgmSbr");
            _musicSbr = (GSlider)GetChild("musicSbr");
            _title_voice = (GTextField)GetChild("title_voice");
            _visual = (GTextField)GetChild("visual");
            _pictureBtn1 = (settingSel0)GetChild("pictureBtn1");
            _frameTxt = (GTextField)GetChild("frameTxt");
            _framesBtn1 = (settingSel1)GetChild("framesBtn1");
            _shielding = (GTextField)GetChild("shielding");
            _hurtText = (GTextField)GetChild("hurtText");
            _effectsSwitch = (settingSwitchBtn1)GetChild("effectsSwitch");
            _hurtTextSwitch = (settingSwitchBtn1)GetChild("hurtTextSwitch");
            _troopNumText = (GTextField)GetChild("troopNumText");
            _troopNumBtn = (settingSel0)GetChild("troopNumBtn");
            _tab1 = (GGroup)GetChild("tab1");
            _playerIcon = (GButton)GetChild("playerIcon");
            _playerName = (GTextField)GetChild("playerName");
            _serverName = (GTextField)GetChild("serverName");
            _announcementBtn = (GButton)GetChild("announcementBtn");
            _customerServiceBtn = (GButton)GetChild("customerServiceBtn");
            _switchSccountsBtn = (GButton)GetChild("switchSccountsBtn");
            _bottom = (GGroup)GetChild("bottom");
            _setting = (GGroup)GetChild("setting");
            _addCopyBtn = (GButton)GetChild("addCopyBtn");
            _awardBtn = (GButton)GetChild("awardBtn");
            _inputCodeTxt = (GTextInput)GetChild("inputCodeTxt");
            _txtCopyBtn = (GButton)GetChild("txtCopyBtn");
            _gift = (GGroup)GetChild("gift");
        }
    }
}