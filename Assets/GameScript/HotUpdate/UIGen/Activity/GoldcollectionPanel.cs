/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class GoldcollectionPanel : GComponent
    {
        public GLoader _Personal_leader;
        public GLoader _prospect;
        public GLoader _icon;
        public GTextField _title_name;
        public GTextField _describelbl;
        public GList _rewardList;
        public GButton _goToBtn;
        public GTextField _time1;
        public GTextField _time2;
        public GButton _explainBtn;
        public GGroup _window;
        public GButton _returnBtn;
        public GTextField _name;
        public GTextField _stress;
        public GTextField _describe;
        public GList _des_list;
        public GGroup _desTip;
        public Transition _t0;
        public Transition _t1;
        public const string URL = "ui://sinorujtl7h11ygcfs9";

        public static GoldcollectionPanel CreateInstance()
        {
            return (GoldcollectionPanel)UIPackage.CreateObject("Activity", "GoldcollectionPanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _Personal_leader = (GLoader)GetChild("Personal_leader");
            _prospect = (GLoader)GetChild("prospect");
            _icon = (GLoader)GetChild("icon");
            _title_name = (GTextField)GetChild("title_name");
            _describelbl = (GTextField)GetChild("describelbl");
            _rewardList = (GList)GetChild("rewardList");
            _goToBtn = (GButton)GetChild("goToBtn");
            _time1 = (GTextField)GetChild("time1");
            _time2 = (GTextField)GetChild("time2");
            _explainBtn = (GButton)GetChild("explainBtn");
            _window = (GGroup)GetChild("window");
            _returnBtn = (GButton)GetChild("returnBtn");
            _name = (GTextField)GetChild("name");
            _stress = (GTextField)GetChild("stress");
            _describe = (GTextField)GetChild("describe");
            _des_list = (GList)GetChild("des_list");
            _desTip = (GGroup)GetChild("desTip");
            _t0 = GetTransition("t0");
            _t1 = GetTransition("t1");
        }
    }
}