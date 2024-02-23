/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class Child_TodayView : GComponent
    {
        public GLoader _icon1;
        public GTextField _explainLbl01;
        public GTextField _explainLbl02;
        public GTextField _explainLbl03;
        public GLoader _icon2;
        public PriceBtn _priceBtn;
        public DailyDirectItem _rewardCom;
        public Transition _admission;
        public const string URL = "ui://340eighfs1uz1ygcfl7";

        public static Child_TodayView CreateInstance()
        {
            return (Child_TodayView)UIPackage.CreateObject("Welfare", "Child_TodayView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _icon1 = (GLoader)GetChild("icon1");
            _explainLbl01 = (GTextField)GetChild("explainLbl01");
            _explainLbl02 = (GTextField)GetChild("explainLbl02");
            _explainLbl03 = (GTextField)GetChild("explainLbl03");
            _icon2 = (GLoader)GetChild("icon2");
            _priceBtn = (PriceBtn)GetChild("priceBtn");
            _rewardCom = (DailyDirectItem)GetChild("rewardCom");
            _admission = GetTransition("admission");
        }
    }
}