/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ServiceActivity
{
    public partial class daysTaskItem1 : GComponent
    {
        public Controller _state;
        public GTextField _title;
        public GTextField _num;
        public GButton _goBtn;
        public GList _icon_list;
        public GButton _receiveBtn;
        public Transition _quit;
        public Transition _admission;
        public const string URL = "ui://e290e74sqf2s1ygcfpy";

        public static daysTaskItem1 CreateInstance()
        {
            return (daysTaskItem1)UIPackage.CreateObject("ServiceActivity", "daysTaskItem1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _title = (GTextField)GetChild("title");
            _num = (GTextField)GetChild("num");
            _goBtn = (GButton)GetChild("goBtn");
            _icon_list = (GList)GetChild("icon_list");
            _receiveBtn = (GButton)GetChild("receiveBtn");
            _quit = GetTransition("quit");
            _admission = GetTransition("admission");
        }
    }
}