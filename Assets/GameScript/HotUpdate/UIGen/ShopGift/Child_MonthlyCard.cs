/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ShopGift
{
    public partial class Child_MonthlyCard : GComponent
    {
        public GLoader _bg;
        public GTextField _title;
        public GList _cardList;
        public GButton _btnExplain;
        public GGroup _windows;
        public Transition _t0;
        public const string URL = "ui://e290e74se8ok1ygcfph";

        public static Child_MonthlyCard CreateInstance()
        {
            return (Child_MonthlyCard)UIPackage.CreateObject("ShopGift", "Child_MonthlyCard");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GLoader)GetChild("bg");
            _title = (GTextField)GetChild("title");
            _cardList = (GList)GetChild("cardList");
            _btnExplain = (GButton)GetChild("btnExplain");
            _windows = (GGroup)GetChild("windows");
            _t0 = GetTransition("t0");
        }
    }
}