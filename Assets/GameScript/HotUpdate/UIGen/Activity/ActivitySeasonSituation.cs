/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class ActivitySeasonSituation : GLabel
    {
        public GTree _rule_list;
        public GButton _closeBtn;
        public GGroup _activity;
        public const string URL = "ui://sinorujtx5ob1ygcfm9";

        public static ActivitySeasonSituation CreateInstance()
        {
            return (ActivitySeasonSituation)UIPackage.CreateObject("Activity", "ActivitySeasonSituation");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _rule_list = (GTree)GetChild("rule_list");
            _closeBtn = (GButton)GetChild("closeBtn");
            _activity = (GGroup)GetChild("activity");
        }
    }
}