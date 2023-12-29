/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogLeaBossView : GLabel
    {
        public GComponent _mask;
        public GButton _btnNext;
        public GButton _showTopTitle;
        public GImage _window;
        public GTextField _txtDesc;
        public GList _ranking_list;
        public GTextField _rankinglbl;
        public GTextField _hurtLbl;
        public GImage _minebg;
        public GImage _awardbg;
        public GTextField _rewardlbl;
        public GList _rewardList2;
        public GTextField _rewardlbl01;
        public GTextField _reward1;
        public GTextField _reward2;
        public GImage _horn1;
        public GImage _horn2;
        public GList _rewardList1;
        public GGroup _com;
        public GGroup _panel;
        public GTextField _lable;
        public Transition _t0;
        public const string URL = "ui://utp01xiaya6w1ygcfsy";

        public static DialogLeaBossView CreateInstance()
        {
            return (DialogLeaBossView)UIPackage.CreateObject("DialogTip", "DialogLeaBossView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _btnNext = (GButton)GetChild("btnNext");
            _showTopTitle = (GButton)GetChild("showTopTitle");
            _window = (GImage)GetChild("window");
            _txtDesc = (GTextField)GetChild("txtDesc");
            _ranking_list = (GList)GetChild("ranking_list");
            _rankinglbl = (GTextField)GetChild("rankinglbl");
            _hurtLbl = (GTextField)GetChild("hurtLbl");
            _minebg = (GImage)GetChild("minebg");
            _awardbg = (GImage)GetChild("awardbg");
            _rewardlbl = (GTextField)GetChild("rewardlbl");
            _rewardList2 = (GList)GetChild("rewardList2");
            _rewardlbl01 = (GTextField)GetChild("rewardlbl01");
            _reward1 = (GTextField)GetChild("reward1");
            _reward2 = (GTextField)GetChild("reward2");
            _horn1 = (GImage)GetChild("horn1");
            _horn2 = (GImage)GetChild("horn2");
            _rewardList1 = (GList)GetChild("rewardList1");
            _com = (GGroup)GetChild("com");
            _panel = (GGroup)GetChild("panel");
            _lable = (GTextField)GetChild("lable");
            _t0 = GetTransition("t0");
        }
    }
}