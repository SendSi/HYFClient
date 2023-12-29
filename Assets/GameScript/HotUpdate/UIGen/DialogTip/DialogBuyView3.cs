/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogBuyView3 : GLabel
    {
        public GComponent _mask;
        public GTextField _titleTxt;
        public contentTxt _contentTxt;
        public GButton _btnLeft;
        public GButton _btnRight;
        public GTextField _hadTxt;
        public GButton _closeButton;
        public GGroup _window;
        public const string URL = "ui://utp01xiabwlb1iy5bbn";

        public static DialogBuyView3 CreateInstance()
        {
            return (DialogBuyView3)UIPackage.CreateObject("DialogTip", "DialogBuyView3");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _titleTxt = (GTextField)GetChild("titleTxt");
            _contentTxt = (contentTxt)GetChild("contentTxt");
            _btnLeft = (GButton)GetChild("btnLeft");
            _btnRight = (GButton)GetChild("btnRight");
            _hadTxt = (GTextField)GetChild("hadTxt");
            _closeButton = (GButton)GetChild("closeButton");
            _window = (GGroup)GetChild("window");
        }
    }
}