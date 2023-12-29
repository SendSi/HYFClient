/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
    public partial class title_notice1 : GComponent
    {
        public GRichTextField _noticeContent;
        public const string URL = "ui://byy9k3gha9my1ygcg9z";

        public static title_notice1 CreateInstance()
        {
            return (title_notice1)UIPackage.CreateObject("Login", "title_notice1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _noticeContent = (GRichTextField)GetChild("noticeContent");
        }
    }
}