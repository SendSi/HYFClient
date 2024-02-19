/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class activity_item3 : GComponent
    {
        public GTextField _title;
        public const string URL = "ui://sinorujtmizd1ygcfs2";

        public static activity_item3 CreateInstance()
        {
            return (activity_item3)UIPackage.CreateObject("Activity", "activity_item3");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _title = (GTextField)GetChild("title");
        }
    }
}