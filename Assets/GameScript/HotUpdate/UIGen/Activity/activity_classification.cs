/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class activity_classification : GComponent
    {
        public GTextField _title;
        public const string URL = "ui://sinorujtw84wq";

        public static activity_classification CreateInstance()
        {
            return (activity_classification)UIPackage.CreateObject("Activity", "activity_classification");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _title = (GTextField)GetChild("title");
        }
    }
}