/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogCityUpgradeView : GLabel
    {
        public Controller _state;
        public GComponent _mask;
        public GImage _window;
        public GTextField _lable;
        public GTextField _txtupgrade;
        public GTextField _number;
        public GList _num_list;
        public GImage _light;
        public GTextField _unlock;
        public GButton _closeButton;
        public GList _building_list;
        public GGroup _windows;
        public Transition _t0;
        public const string URL = "ui://utp01xiavnkq1ygcfht";

        public static DialogCityUpgradeView CreateInstance()
        {
            return (DialogCityUpgradeView)UIPackage.CreateObject("DialogTip", "DialogCityUpgradeView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _mask = (GComponent)GetChild("mask");
            _window = (GImage)GetChild("window");
            _lable = (GTextField)GetChild("lable");
            _txtupgrade = (GTextField)GetChild("txtupgrade");
            _number = (GTextField)GetChild("number");
            _num_list = (GList)GetChild("num_list");
            _light = (GImage)GetChild("light");
            _unlock = (GTextField)GetChild("unlock");
            _closeButton = (GButton)GetChild("closeButton");
            _building_list = (GList)GetChild("building_list");
            _windows = (GGroup)GetChild("windows");
            _t0 = GetTransition("t0");
        }
    }
}