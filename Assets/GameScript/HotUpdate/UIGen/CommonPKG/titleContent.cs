/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class titleContent : GComponent
    {
        public GRichTextField _noticeContent;
        public const string URL = "ui://2r331opvmnqw1ygcga8";

        public static titleContent CreateInstance()
        {
            return (titleContent)UIPackage.CreateObject("CommonPKG", "titleContent");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _noticeContent = (GRichTextField)GetChild("noticeContent");
        }
    }
}