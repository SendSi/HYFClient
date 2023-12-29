/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogTip6View : GLabel
    {
        public GComponent _mask;
        public GLabel _bg;
        public GTextField _titleTxt;
        public GButton _btnCenter;
        public GButton _closeButton;
        public GTextField _contentTitle;
        public GTextField _contentTitle1;
        public GGroup _window;
        public const string URL = "ui://utp01xiasumv1ygcfhu";

        public static DialogTip6View CreateInstance()
        {
            return (DialogTip6View)UIPackage.CreateObject("DialogTip", "DialogTip6View");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _bg = (GLabel)GetChild("bg");
            _titleTxt = (GTextField)GetChild("titleTxt");
            _btnCenter = (GButton)GetChild("btnCenter");
            _closeButton = (GButton)GetChild("closeButton");
            _contentTitle = (GTextField)GetChild("contentTitle");
            _contentTitle1 = (GTextField)GetChild("contentTitle1");
            _window = (GGroup)GetChild("window");
        }
    }
}