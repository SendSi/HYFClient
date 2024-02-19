/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ServiceActivity
{
    public partial class rechargeItem : GComponent
    {
        public Controller _state;
        public GLoader _bg;
        public GList _icon_list;
        public GButton _receiveBtn;
        public GTextField _title2;
        public GTextField _time;
        public GGroup _time_des;
        public GGraph _boosbg;
        public GTextField _smash;
        public GTextField _boss;
        public GGroup _text;
        public Transition _admission;
        public const string URL = "ui://e290e74snkto1ygcfpx";

        public static rechargeItem CreateInstance()
        {
            return (rechargeItem)UIPackage.CreateObject("ServiceActivity", "rechargeItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _bg = (GLoader)GetChild("bg");
            _icon_list = (GList)GetChild("icon_list");
            _receiveBtn = (GButton)GetChild("receiveBtn");
            _title2 = (GTextField)GetChild("title2");
            _time = (GTextField)GetChild("time");
            _time_des = (GGroup)GetChild("time_des");
            _boosbg = (GGraph)GetChild("boosbg");
            _smash = (GTextField)GetChild("smash");
            _boss = (GTextField)GetChild("boss");
            _text = (GGroup)GetChild("text");
            _admission = GetTransition("admission");
        }
    }
}