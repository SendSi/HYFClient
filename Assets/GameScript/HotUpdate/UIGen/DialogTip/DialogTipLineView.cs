/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogTipLineView : GLabel
    {
        public GComponent _mask;
        public GLabel _bg;
        public contentTxt _contentTxt;
        public GRichTextField _lineTxt;
        public GButton _btnLeft;
        public GButton _btnRight;
        public GButton _closeButton;
        public GTextField _titleTxt;
        public GGroup _win;
        public const string URL = "ui://utp01xiad7y82n";

        public static DialogTipLineView CreateInstance()
        {
            return (DialogTipLineView)UIPackage.CreateObject("DialogTip", "DialogTipLineView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _bg = (GLabel)GetChild("bg");
            _contentTxt = (contentTxt)GetChild("contentTxt");
            _lineTxt = (GRichTextField)GetChild("lineTxt");
            _btnLeft = (GButton)GetChild("btnLeft");
            _btnRight = (GButton)GetChild("btnRight");
            _closeButton = (GButton)GetChild("closeButton");
            _titleTxt = (GTextField)GetChild("titleTxt");
            _win = (GGroup)GetChild("win");
        }
    }
}