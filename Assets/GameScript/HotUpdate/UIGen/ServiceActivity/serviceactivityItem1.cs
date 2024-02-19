/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ServiceActivity
{
    public partial class serviceactivityItem1 : GComponent
    {
        public Controller _state;
        public Controller _select;
        public Controller _day;
        public GLoader _bg;
        public serviceactivityLabel _label;
        public GLoader _name;
        public GTextField _dayLbl;
        public GTextField _dayLbl01;
        public GList _icon01;
        public GButton _icon;
        public const string URL = "ui://e290e74sho401ygcfka";

        public static serviceactivityItem1 CreateInstance()
        {
            return (serviceactivityItem1)UIPackage.CreateObject("ServiceActivity", "serviceactivityItem1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _select = GetController("select");
            _day = GetController("day");
            _bg = (GLoader)GetChild("bg");
            _label = (serviceactivityLabel)GetChild("label");
            _name = (GLoader)GetChild("name");
            _dayLbl = (GTextField)GetChild("dayLbl");
            _dayLbl01 = (GTextField)GetChild("dayLbl01");
            _icon01 = (GList)GetChild("icon01");
            _icon = (GButton)GetChild("icon");
        }
    }
}