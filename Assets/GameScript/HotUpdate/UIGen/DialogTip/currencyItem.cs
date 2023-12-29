/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class currencyItem : GComponent
    {
        public Controller _state;
        public GImage _bg1;
        public GLoader _icon;
        public GTextField _title;
        public GTextField _firstLbl;
        public GButton _RechargeBtn;
        public const string URL = "ui://utp01xiat6g91ygcfhr";

        public static currencyItem CreateInstance()
        {
            return (currencyItem)UIPackage.CreateObject("DialogTip", "currencyItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _bg1 = (GImage)GetChild("bg1");
            _icon = (GLoader)GetChild("icon");
            _title = (GTextField)GetChild("title");
            _firstLbl = (GTextField)GetChild("firstLbl");
            _RechargeBtn = (GButton)GetChild("RechargeBtn");
        }
    }
}