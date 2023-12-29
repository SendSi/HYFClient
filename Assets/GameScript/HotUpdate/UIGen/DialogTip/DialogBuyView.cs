/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogBuyView : GLabel
    {
        public GComponent _mask;
        public GButton _closeButton;
        public GButton _window;
        public GButton _propIcon;
        public GButton _cutBtn;
        public GButton _plusBtn;
        public GLoader _currencyIcon;
        public GTextField _currencyName;
        public GTextField _needNum;
        public GButton _buyBtn;
        public const string URL = "ui://utp01xiaix8t2r";

        public static DialogBuyView CreateInstance()
        {
            return (DialogBuyView)UIPackage.CreateObject("DialogTip", "DialogBuyView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _closeButton = (GButton)GetChild("closeButton");
            _window = (GButton)GetChild("window");
            _propIcon = (GButton)GetChild("propIcon");
            _cutBtn = (GButton)GetChild("cutBtn");
            _plusBtn = (GButton)GetChild("plusBtn");
            _currencyIcon = (GLoader)GetChild("currencyIcon");
            _currencyName = (GTextField)GetChild("currencyName");
            _needNum = (GTextField)GetChild("needNum");
            _buyBtn = (GButton)GetChild("buyBtn");
        }
    }
}