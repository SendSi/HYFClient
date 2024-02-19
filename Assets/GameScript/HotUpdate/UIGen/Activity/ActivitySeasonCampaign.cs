/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class ActivitySeasonCampaign : GComponent
    {
        public GTextField _title;
        public GList _recruit_list;
        public const string URL = "ui://sinorujtf36a1ygcfmf";

        public static ActivitySeasonCampaign CreateInstance()
        {
            return (ActivitySeasonCampaign)UIPackage.CreateObject("Activity", "ActivitySeasonCampaign");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _title = (GTextField)GetChild("title");
            _recruit_list = (GList)GetChild("recruit_list");
        }
    }
}