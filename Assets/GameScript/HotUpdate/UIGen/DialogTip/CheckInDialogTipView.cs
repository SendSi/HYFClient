/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class CheckInDialogTipView : GLabel
    {
        public Controller _state;
        public GComponent _mask;
        public GLabel _bg;
        public GTextField _titleTxt;
        public GButton _btnLeft;
        public GButton _btnRight;
        public GButton _closeButton;
        public GTextField _contentTitle;
        public GRichTextField _conditionLbl;
        public GGroup _win;
        public const string URL = "ui://utp01xiab0uj1ygcfhs";

        public static CheckInDialogTipView CreateInstance()
        {
            return (CheckInDialogTipView)UIPackage.CreateObject("DialogTip", "CheckInDialogTipView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _mask = (GComponent)GetChild("mask");
            _bg = (GLabel)GetChild("bg");
            _titleTxt = (GTextField)GetChild("titleTxt");
            _btnLeft = (GButton)GetChild("btnLeft");
            _btnRight = (GButton)GetChild("btnRight");
            _closeButton = (GButton)GetChild("closeButton");
            _contentTitle = (GTextField)GetChild("contentTitle");
            _conditionLbl = (GRichTextField)GetChild("conditionLbl");
            _win = (GGroup)GetChild("win");
        }
    }
}