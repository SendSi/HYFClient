/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class Child_TodayView : GComponent
    {
        public GLoader _icon;
        public GTextField _explainLbl01;
        public GTextField _explainLbl02;
        public GTextField _explainLbl03;
        public GLoader _icon01;
        public PriceBtn _PriceBtn;
        public DailyDirectItem _list;
        public Transition _admission;
        public const string URL = "ui://340eighfs1uz1ygcfl7";

        public static Child_TodayView CreateInstance()
        {
            return (Child_TodayView)UIPackage.CreateObject("Welfare", "Child_TodayView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _icon = (GLoader)GetChild("icon");
            _explainLbl01 = (GTextField)GetChild("explainLbl01");
            _explainLbl02 = (GTextField)GetChild("explainLbl02");
            _explainLbl03 = (GTextField)GetChild("explainLbl03");
            _icon01 = (GLoader)GetChild("icon01");
            _PriceBtn = (PriceBtn)GetChild("PriceBtn");
            _list = (DailyDirectItem)GetChild("list");
            _admission = GetTransition("admission");
        }
    }
}