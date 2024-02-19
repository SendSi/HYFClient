/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class ActivitySeasonTip : GLabel
    {
        public Controller _state;
        public GTextField _num;
        public GList _tab;
        public ActivitySeasonRewardNew _award;
        public ActivitySeasonCampaign _tip;
        public GButton _closeBtn;
        public GGroup _activity;
        public const string URL = "ui://sinorujtg6ichz9cza";

        public static ActivitySeasonTip CreateInstance()
        {
            return (ActivitySeasonTip)UIPackage.CreateObject("Activity", "ActivitySeasonTip");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _num = (GTextField)GetChild("num");
            _tab = (GList)GetChild("tab");
            _award = (ActivitySeasonRewardNew)GetChild("award");
            _tip = (ActivitySeasonCampaign)GetChild("tip");
            _closeBtn = (GButton)GetChild("closeBtn");
            _activity = (GGroup)GetChild("activity");
        }
    }
}