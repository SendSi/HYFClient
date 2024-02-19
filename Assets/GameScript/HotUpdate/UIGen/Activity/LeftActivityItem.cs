/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class LeftActivityItem : GButton
    {
        public Controller _iconCtrl;
        public Controller _red;
        public Controller _state;
        public Controller _showHint;
        public GTextField _time;
        public GTextField _actDot;
        public GLoader _label;
        public GTextField _title1;
        public GButton _reddot;
        public Transition _tScale;
        public const string URL = "ui://sinorujtw84wp";

        public static LeftActivityItem CreateInstance()
        {
            return (LeftActivityItem)UIPackage.CreateObject("Activity", "LeftActivityItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _iconCtrl = GetController("iconCtrl");
            _red = GetController("red");
            _state = GetController("state");
            _showHint = GetController("showHint");
            _time = (GTextField)GetChild("time");
            _actDot = (GTextField)GetChild("actDot");
            _label = (GLoader)GetChild("label");
            _title1 = (GTextField)GetChild("title1");
            _reddot = (GButton)GetChild("reddot");
            _tScale = GetTransition("tScale");
        }
    }
}