/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class KillTipItem : GComponent
    {
        public GImage _bg;
        public GRichTextField _titleTxt;
        public GGroup _content;
        public Transition _moveAlpha;
        public const string URL = "ui://utp01xial1qp1ygcfi4";

        public static KillTipItem CreateInstance()
        {
            return (KillTipItem)UIPackage.CreateObject("DialogTip", "KillTipItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GImage)GetChild("bg");
            _titleTxt = (GRichTextField)GetChild("titleTxt");
            _content = (GGroup)GetChild("content");
            _moveAlpha = GetTransition("moveAlpha");
        }
    }
}