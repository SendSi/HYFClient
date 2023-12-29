/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogResultView : GLabel
    {
        public GComponent _mask;
        public GButton _closeButton;
        public GButton _showTopTitle;
        public GImage _window;
        public GTextField _lable;
        public GButton _btnNext;
        public Items_name _centerList;
        public Transition _t0;
        public const string URL = "ui://utp01xiaqi981ygcfn9";

        public static DialogResultView CreateInstance()
        {
            return (DialogResultView)UIPackage.CreateObject("DialogTip", "DialogResultView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _closeButton = (GButton)GetChild("closeButton");
            _showTopTitle = (GButton)GetChild("showTopTitle");
            _window = (GImage)GetChild("window");
            _lable = (GTextField)GetChild("lable");
            _btnNext = (GButton)GetChild("btnNext");
            _centerList = (Items_name)GetChild("centerList");
            _t0 = GetTransition("t0");
        }
    }
}