/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogTipToggleView : GLabel
    {
        public GComponent _mask;
        public GLabel _bg;
        public contentTxt _contentTxt;
        public GTextField _titleTxt;
        public GButton _tipToggleBtn;
        public GTextField _tipToggleTxt;
        public GButton _btnLeft;
        public GButton _btnRight;
        public GButton _closeButton;
        public GGroup _window;
        public const string URL = "ui://utp01xiaxse52o";

        public static DialogTipToggleView CreateInstance()
        {
            return (DialogTipToggleView)UIPackage.CreateObject("DialogTip", "DialogTipToggleView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _bg = (GLabel)GetChild("bg");
            _contentTxt = (contentTxt)GetChild("contentTxt");
            _titleTxt = (GTextField)GetChild("titleTxt");
            _tipToggleBtn = (GButton)GetChild("tipToggleBtn");
            _tipToggleTxt = (GTextField)GetChild("tipToggleTxt");
            _btnLeft = (GButton)GetChild("btnLeft");
            _btnRight = (GButton)GetChild("btnRight");
            _closeButton = (GButton)GetChild("closeButton");
            _window = (GGroup)GetChild("window");
        }
    }
}