/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class ActivitySeasonView : GLabel
    {
        public Controller _state;
        public Controller _draw;
        public GImage _preview;
        public GList _icon_list;
        public GButton _closeBtn;
        public GButton _explainBtn;
        public GList _customs_list;
        public GTextField _overTxt;
        public GTextField _nexttime;
        public GGroup _state1;
        public GTextField _present;
        public GTextField _remainingtime;
        public GTextField _describeTxt;
        public GTextField _target;
        public GTextField _targetDesc;
        public GTextField _occupy;
        public GList _award_list;
        public GButton _receiveBtn;
        public GGroup _state0;
        public GComponent _effectHolder;
        public GGraph _mask;
        public GTextField _time;
        public GGroup _time1;
        public const string URL = "ui://sinorujtg6ichz9czc";

        public static ActivitySeasonView CreateInstance()
        {
            return (ActivitySeasonView)UIPackage.CreateObject("Activity", "ActivitySeasonView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _draw = GetController("draw");
            _preview = (GImage)GetChild("preview");
            _icon_list = (GList)GetChild("icon_list");
            _closeBtn = (GButton)GetChild("closeBtn");
            _explainBtn = (GButton)GetChild("explainBtn");
            _customs_list = (GList)GetChild("customs_list");
            _overTxt = (GTextField)GetChild("overTxt");
            _nexttime = (GTextField)GetChild("nexttime");
            _state1 = (GGroup)GetChild("state1");
            _present = (GTextField)GetChild("present");
            _remainingtime = (GTextField)GetChild("remainingtime");
            _describeTxt = (GTextField)GetChild("describeTxt");
            _target = (GTextField)GetChild("target");
            _targetDesc = (GTextField)GetChild("targetDesc");
            _occupy = (GTextField)GetChild("occupy");
            _award_list = (GList)GetChild("award_list");
            _receiveBtn = (GButton)GetChild("receiveBtn");
            _state0 = (GGroup)GetChild("state0");
            _effectHolder = (GComponent)GetChild("effectHolder");
            _mask = (GGraph)GetChild("mask");
            _time = (GTextField)GetChild("time");
            _time1 = (GGroup)GetChild("time1");
        }
    }
}