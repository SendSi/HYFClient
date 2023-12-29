/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class titleContent : GComponent
    {
        public Controller _col;
        public GTextField _title;
        public const string URL = "ui://4ni413lao4i9z9cju";

        public static titleContent CreateInstance()
        {
            return (titleContent)UIPackage.CreateObject("MainCenter", "titleContent");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _col = GetController("col");
            _title = (GTextField)GetChild("title");
        }
    }
}