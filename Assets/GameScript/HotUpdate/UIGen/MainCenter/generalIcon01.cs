/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class generalIcon01 : GButton
    {
        public Controller _quality;
        public Controller _state;
        public Controller _showPower;
        public Controller _captain;
        public Controller _garrison;
        public Controller _existing;
        public Controller _elementCtrl;
        public GLoader _bg0;
        public GLoader _bg;
        public GLoader _select;
        public GLoader _qualityIcon;
        public GTextField _lv;
        public GLoader _occupation;
        public GLoader _captain_2;
        public GTextField _team;
        public GGroup _team0;
        public GList _starList;
        public main_teamStae _garr_icon;
        public GTextField _powerLbl;
        public GTextField _emptyLbl;
        public GImage _lock;
        public GTextField _countdown;
        public GButton _exist;
        public GComponent _elementIcon;
        public const string URL = "ui://4ni413lahxd7hz9d7l";

        public static generalIcon01 CreateInstance()
        {
            return (generalIcon01)UIPackage.CreateObject("MainCenter", "generalIcon01");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _quality = GetController("quality");
            _state = GetController("state");
            _showPower = GetController("showPower");
            _captain = GetController("captain");
            _garrison = GetController("garrison");
            _existing = GetController("existing");
            _elementCtrl = GetController("elementCtrl");
            _bg0 = (GLoader)GetChild("bg0");
            _bg = (GLoader)GetChild("bg");
            _select = (GLoader)GetChild("select");
            _qualityIcon = (GLoader)GetChild("qualityIcon");
            _lv = (GTextField)GetChild("lv");
            _occupation = (GLoader)GetChild("occupation");
            _captain_2 = (GLoader)GetChild("captain");
            _team = (GTextField)GetChild("team");
            _team0 = (GGroup)GetChild("team0");
            _starList = (GList)GetChild("starList");
            _garr_icon = (main_teamStae)GetChild("garr_icon");
            _powerLbl = (GTextField)GetChild("powerLbl");
            _emptyLbl = (GTextField)GetChild("emptyLbl");
            _lock = (GImage)GetChild("lock");
            _countdown = (GTextField)GetChild("countdown");
            _exist = (GButton)GetChild("exist");
            _elementIcon = (GComponent)GetChild("elementIcon");
        }
    }
}