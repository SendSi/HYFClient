/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class ActFindResMainView : GLabel
    {
        public Controller _state;
        public GButton _closeButton;
        public GButton _explainBtn;
        public GTextField _descTxt;
        public GTextField _day;
        public GList _resList;
        public GButton _moneyBtn;
        public GButton _freeBtn;
        public GTextField _freeTxt;
        public GTextField _moneyTxt;
        public GGroup _sta1;
        public GTextField _recoverTxt;
        public GTextField _recoverTxt1;
        public GGroup _sta2;
        public GGroup _activity;
        public const string URL = "ui://sinorujtd7a61ygcfiz";

        public static ActFindResMainView CreateInstance()
        {
            return (ActFindResMainView)UIPackage.CreateObject("Activity", "ActFindResMainView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _closeButton = (GButton)GetChild("closeButton");
            _explainBtn = (GButton)GetChild("explainBtn");
            _descTxt = (GTextField)GetChild("descTxt");
            _day = (GTextField)GetChild("day");
            _resList = (GList)GetChild("resList");
            _moneyBtn = (GButton)GetChild("moneyBtn");
            _freeBtn = (GButton)GetChild("freeBtn");
            _freeTxt = (GTextField)GetChild("freeTxt");
            _moneyTxt = (GTextField)GetChild("moneyTxt");
            _sta1 = (GGroup)GetChild("sta1");
            _recoverTxt = (GTextField)GetChild("recoverTxt");
            _recoverTxt1 = (GTextField)GetChild("recoverTxt1");
            _sta2 = (GGroup)GetChild("sta2");
            _activity = (GGroup)GetChild("activity");
        }
    }
}