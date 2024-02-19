/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class DefendCityActPanel : GLabel
    {
        public GLoader _bg;
        public GList _rewardList;
        public GButton _goToBtn;
        public GButton _explainBtn;
        public GTextField _describelbl;
        public GGroup _window;
        public GButton _returnBtn;
        public GTextField _name;
        public GTextField _stress;
        public GTextField _describe;
        public GList _des_list;
        public GGroup _desTip;
        public Transition _t0;
        public Transition _t1;
        public const string URL = "ui://sinorujti3znhz9cyk";

        public static DefendCityActPanel CreateInstance()
        {
            return (DefendCityActPanel)UIPackage.CreateObject("Activity", "DefendCityActPanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GLoader)GetChild("bg");
            _rewardList = (GList)GetChild("rewardList");
            _goToBtn = (GButton)GetChild("goToBtn");
            _explainBtn = (GButton)GetChild("explainBtn");
            _describelbl = (GTextField)GetChild("describelbl");
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