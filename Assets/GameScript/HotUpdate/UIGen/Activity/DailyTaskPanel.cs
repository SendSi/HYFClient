/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class DailyTaskPanel : GComponent
    {
        public GLoader _Personal_leader;
        public GTextField _title;
        public GTextField _title02;
        public GList _list;
        public dailyBar1 _bar;
        public GButton _goBtn;
        public const string URL = "ui://sinorujtk6h81ygcfi7";

        public static DailyTaskPanel CreateInstance()
        {
            return (DailyTaskPanel)UIPackage.CreateObject("Activity", "DailyTaskPanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _Personal_leader = (GLoader)GetChild("Personal_leader");
            _title = (GTextField)GetChild("title");
            _title02 = (GTextField)GetChild("title02");
            _list = (GList)GetChild("list");
            _bar = (dailyBar1)GetChild("bar");
            _goBtn = (GButton)GetChild("goBtn");
        }
    }
}