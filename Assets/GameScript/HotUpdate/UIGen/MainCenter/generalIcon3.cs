/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class generalIcon3 : GButton
    {
        public Controller _reincarnation;
        public Controller _star;
        public Controller _quality;
        public Controller _troops;
        public Controller _state;
        public Controller _empty;
        public GLoader _bg0;
        public GLoader _bg;
        public GTextField _noTroop;
        public GLoader _qualityIcon;
        public GTextField _lv;
        public GComponent _star0;
        public GComponent _star1;
        public GComponent _star2;
        public GComponent _star3;
        public GComponent _star4;
        public GComponent _star5;
        public GComponent _star6;
        public GTextField _troopTitle;
        public GTextField _newTitle;
        public main_teamStae _troopState;
        public GTextField _power;
        public Transition _t0;
        public const string URL = "ui://4ni413ladmmmhz9d2y";

        public static generalIcon3 CreateInstance()
        {
            return (generalIcon3)UIPackage.CreateObject("MainCenter", "generalIcon3");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _reincarnation = GetController("reincarnation");
            _star = GetController("star");
            _quality = GetController("quality");
            _troops = GetController("troops");
            _state = GetController("state");
            _empty = GetController("empty");
            _bg0 = (GLoader)GetChild("bg0");
            _bg = (GLoader)GetChild("bg");
            _noTroop = (GTextField)GetChild("noTroop");
            _qualityIcon = (GLoader)GetChild("qualityIcon");
            _lv = (GTextField)GetChild("lv");
            _star0 = (GComponent)GetChild("star0");
            _star1 = (GComponent)GetChild("star1");
            _star2 = (GComponent)GetChild("star2");
            _star3 = (GComponent)GetChild("star3");
            _star4 = (GComponent)GetChild("star4");
            _star5 = (GComponent)GetChild("star5");
            _star6 = (GComponent)GetChild("star6");
            _troopTitle = (GTextField)GetChild("troopTitle");
            _newTitle = (GTextField)GetChild("newTitle");
            _troopState = (main_teamStae)GetChild("troopState");
            _power = (GTextField)GetChild("power");
            _t0 = GetTransition("t0");
        }
    }
}