/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogTip1View : GLabel
    {
        public GComponent _mask;
        public GLabel _frame;
        public contentTxt _contentTxt;
        public GButton _btnCenter;
        public const string URL = "ui://utp01xiam79t2l";

        public static DialogTip1View CreateInstance()
        {
            return (DialogTip1View)UIPackage.CreateObject("DialogTip", "DialogTip1View");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _frame = (GLabel)GetChild("frame");
            _contentTxt = (contentTxt)GetChild("contentTxt");
            _btnCenter = (GButton)GetChild("btnCenter");
        }
    }
}