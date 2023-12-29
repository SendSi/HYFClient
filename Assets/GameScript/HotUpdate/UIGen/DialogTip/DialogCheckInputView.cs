/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogCheckInputView : GLabel
    {
        public GComponent _mask;
        public GLabel _bg;
        public GTextField _titleTxt;
        public contentTxt _contentTxt;
        public GButton _btnLeft;
        public GButton _btnRight;
        public GTextInput _checkInput;
        public GButton _closeButton;
        public GGroup _win;
        public const string URL = "ui://utp01xiajdqkkx";

        public static DialogCheckInputView CreateInstance()
        {
            return (DialogCheckInputView)UIPackage.CreateObject("DialogTip", "DialogCheckInputView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _bg = (GLabel)GetChild("bg");
            _titleTxt = (GTextField)GetChild("titleTxt");
            _contentTxt = (contentTxt)GetChild("contentTxt");
            _btnLeft = (GButton)GetChild("btnLeft");
            _btnRight = (GButton)GetChild("btnRight");
            _checkInput = (GTextInput)GetChild("checkInput");
            _closeButton = (GButton)GetChild("closeButton");
            _win = (GGroup)GetChild("win");
        }
    }
}