/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogUsingView : GLabel
    {
        public GComponent _mask;
        public GButton _closeTTT;
        public GButton _window;
        public GButton _propIcon;
        public GButton _cutBtn;
        public GButton _plusBtn;
        public GTextInput _inputTxt;
        public GTextField _currencyName;
        public GTextField _hasNum;
        public GButton _buyBtn;
        public const string URL = "ui://utp01xiasz581ygcftb";

        public static DialogUsingView CreateInstance()
        {
            return (DialogUsingView)UIPackage.CreateObject("DialogTip", "DialogUsingView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _closeTTT = (GButton)GetChild("closeTTT");
            _window = (GButton)GetChild("window");
            _propIcon = (GButton)GetChild("propIcon");
            _cutBtn = (GButton)GetChild("cutBtn");
            _plusBtn = (GButton)GetChild("plusBtn");
            _inputTxt = (GTextInput)GetChild("inputTxt");
            _currencyName = (GTextField)GetChild("currencyName");
            _hasNum = (GTextField)GetChild("hasNum");
            _buyBtn = (GButton)GetChild("buyBtn");
        }
    }
}