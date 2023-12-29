/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogBarrierView : GLabel
    {
        public Controller _grayed;
        public GComponent _mask;
        public GButton _showTopTitle;
        public GImage _window;
        public GButton _null;
        public GTextField _titleSucc1;
        public GTextField _titleSucc2;
        public Item1 _centerList;
        public GList _award_list;
        public GButton _nextBtn;
        public GButton _outBtn;
        public GTextField _titleSucc3;
        public Transition _t0;
        public const string URL = "ui://utp01xiaoojm1ygcfi1";

        public static DialogBarrierView CreateInstance()
        {
            return (DialogBarrierView)UIPackage.CreateObject("DialogTip", "DialogBarrierView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _grayed = GetController("grayed");
            _mask = (GComponent)GetChild("mask");
            _showTopTitle = (GButton)GetChild("showTopTitle");
            _window = (GImage)GetChild("window");
            _null = (GButton)GetChild("null");
            _titleSucc1 = (GTextField)GetChild("titleSucc1");
            _titleSucc2 = (GTextField)GetChild("titleSucc2");
            _centerList = (Item1)GetChild("centerList");
            _award_list = (GList)GetChild("award_list");
            _nextBtn = (GButton)GetChild("nextBtn");
            _outBtn = (GButton)GetChild("outBtn");
            _titleSucc3 = (GTextField)GetChild("titleSucc3");
            _t0 = GetTransition("t0");
        }
    }
}