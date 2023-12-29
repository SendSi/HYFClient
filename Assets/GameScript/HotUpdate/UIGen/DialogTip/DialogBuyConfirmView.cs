/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogBuyConfirmView : GLabel
    {
        public GComponent _mask;
        public GButton _closeButton;
        public GButton _window;
        public GButton _propIcon;
        public GTextField _title2;
        public GTextField _tips;
        public GButton _buyBtn;
        public const string URL = "ui://utp01xiad4a62v";

        public static DialogBuyConfirmView CreateInstance()
        {
            return (DialogBuyConfirmView)UIPackage.CreateObject("DialogTip", "DialogBuyConfirmView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _closeButton = (GButton)GetChild("closeButton");
            _window = (GButton)GetChild("window");
            _propIcon = (GButton)GetChild("propIcon");
            _title2 = (GTextField)GetChild("title2");
            _tips = (GTextField)GetChild("tips");
            _buyBtn = (GButton)GetChild("buyBtn");
        }
    }
}