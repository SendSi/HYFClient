/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogTip2View : GLabel
    {
        public GComponent _mask;
        public GLabel _frame;
        public contentTxt _contentTxt;
        public GButton _btnLeft;
        public GButton _btnRight;
        public GGroup _win;
        public const string URL = "ui://utp01xiam79t16";

        public static DialogTip2View CreateInstance()
        {
            return (DialogTip2View)UIPackage.CreateObject("DialogTip", "DialogTip2View");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _frame = (GLabel)GetChild("frame");
            _contentTxt = (contentTxt)GetChild("contentTxt");
            _btnLeft = (GButton)GetChild("btnLeft");
            _btnRight = (GButton)GetChild("btnRight");
            _win = (GGroup)GetChild("win");
        }
    }
}