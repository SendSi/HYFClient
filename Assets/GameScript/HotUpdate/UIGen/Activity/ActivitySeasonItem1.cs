/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class ActivitySeasonItem1 : GComponent
    {
        public GTextField _title;
        public const string URL = "ui://sinorujtf36a1ygcfmg";

        public static ActivitySeasonItem1 CreateInstance()
        {
            return (ActivitySeasonItem1)UIPackage.CreateObject("Activity", "ActivitySeasonItem1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _title = (GTextField)GetChild("title");
        }
    }
}