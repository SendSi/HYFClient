/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class rankRewardItem : GButton
    {
        public Controller _quality;
        public GList _listItem;
        public const string URL = "ui://sinorujttg9hhz9d0j";

        public static rankRewardItem CreateInstance()
        {
            return (rankRewardItem)UIPackage.CreateObject("Activity", "rankRewardItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _quality = GetController("quality");
            _listItem = (GList)GetChild("listItem");
        }
    }
}