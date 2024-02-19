/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class TaskActPanel : GComponent
    {
        public GLoader _Personal_leader;
        public GLoader _prospect;
        public GTextField _title_name;
        public GTextField _describelbl;
        public GList _rewardList;
        public GButton _goToBtn;
        public GTextField _lbl01;
        public const string URL = "ui://sinorujt10xg71ygcffa";

        public static TaskActPanel CreateInstance()
        {
            return (TaskActPanel)UIPackage.CreateObject("Activity", "TaskActPanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _Personal_leader = (GLoader)GetChild("Personal_leader");
            _prospect = (GLoader)GetChild("prospect");
            _title_name = (GTextField)GetChild("title_name");
            _describelbl = (GTextField)GetChild("describelbl");
            _rewardList = (GList)GetChild("rewardList");
            _goToBtn = (GButton)GetChild("goToBtn");
            _lbl01 = (GTextField)GetChild("lbl01");
        }
    }
}