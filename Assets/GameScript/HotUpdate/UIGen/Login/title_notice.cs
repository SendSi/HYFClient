/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
    public partial class title_notice : GComponent
    {
        public Controller _type;
        public GRichTextField _noticeTitle;
        public GRichTextField _noticeContent;
        public GLoader _bgimg;
        public const string URL = "ui://byy9k3ghefn9y";

        public static title_notice CreateInstance()
        {
            return (title_notice)UIPackage.CreateObject("Login", "title_notice");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _type = GetController("type");
            _noticeTitle = (GRichTextField)GetChild("noticeTitle");
            _noticeContent = (GRichTextField)GetChild("noticeContent");
            _bgimg = (GLoader)GetChild("bgimg");
        }
    }
}