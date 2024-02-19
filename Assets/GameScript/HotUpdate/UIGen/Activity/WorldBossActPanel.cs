/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class WorldBossActPanel : GLabel
    {
        public Controller _state;
        public GLoader _bg;
        public GLoader _prospect;
        public GTextField _title_name;
        public GTextField _time;
        public GTextField _describelbl;
        public GList _rewardList;
        public GButton _goToBtn;
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
        public const string URL = "ui://sinorujtlyph16";

        public static WorldBossActPanel CreateInstance()
        {
            return (WorldBossActPanel)UIPackage.CreateObject("Activity", "WorldBossActPanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _bg = (GLoader)GetChild("bg");
            _prospect = (GLoader)GetChild("prospect");
            _title_name = (GTextField)GetChild("title_name");
            _time = (GTextField)GetChild("time");
            _describelbl = (GTextField)GetChild("describelbl");
            _rewardList = (GList)GetChild("rewardList");
            _goToBtn = (GButton)GetChild("goToBtn");
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