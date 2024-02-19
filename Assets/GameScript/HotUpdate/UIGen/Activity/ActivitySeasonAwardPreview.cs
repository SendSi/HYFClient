/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class ActivitySeasonAwardPreview : GLabel
    {
        public GList _rule_list;
        public GTextField _rank;
        public GTextField _official;
        public GTextField _preview;
        public GGroup _activity;
        public const string URL = "ui://sinorujtg6ichz9cz7";

        public static ActivitySeasonAwardPreview CreateInstance()
        {
            return (ActivitySeasonAwardPreview)UIPackage.CreateObject("Activity", "ActivitySeasonAwardPreview");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _rule_list = (GList)GetChild("rule_list");
            _rank = (GTextField)GetChild("rank");
            _official = (GTextField)GetChild("official");
            _preview = (GTextField)GetChild("preview");
            _activity = (GGroup)GetChild("activity");
        }
    }
}