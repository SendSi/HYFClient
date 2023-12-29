/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogRebirthView : GLabel
    {
        public GComponent _mask;
        public GButton _topTitle;
        public GImage _window;
        public GButton _btnNext;
        public RebirthItem1 _centerList;
        public GList _attr_list;
        public GTextField _lable;
        public Transition _t0;
        public const string URL = "ui://utp01xiahe9p1ygcfta";

        public static DialogRebirthView CreateInstance()
        {
            return (DialogRebirthView)UIPackage.CreateObject("DialogTip", "DialogRebirthView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _topTitle = (GButton)GetChild("topTitle");
            _window = (GImage)GetChild("window");
            _btnNext = (GButton)GetChild("btnNext");
            _centerList = (RebirthItem1)GetChild("centerList");
            _attr_list = (GList)GetChild("attr_list");
            _lable = (GTextField)GetChild("lable");
            _t0 = GetTransition("t0");
        }
    }
}