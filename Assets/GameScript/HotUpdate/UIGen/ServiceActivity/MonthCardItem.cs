/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ServiceActivity
{
    public partial class MonthCardItem : GComponent
    {
        public Controller _buyCtrl;
        public Controller _state;
        public GLoader _bg;
        public GTextField _titleLbl;
        public GTextField _titleNum;
        public GTextField _descLbl;
        public MonthCardlabel1 _label;
        public MonthCardlabel2 _label2;
        public GButton _btnClaimed;
        public GButton _btnReward;
        public GButton _BtnBuy;
        public GButton _BtnBuy_next;
        public const string URL = "ui://e290e74stkvp1ygcfpk";

        public static MonthCardItem CreateInstance()
        {
            return (MonthCardItem)UIPackage.CreateObject("ServiceActivity", "MonthCardItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _buyCtrl = GetController("buyCtrl");
            _state = GetController("state");
            _bg = (GLoader)GetChild("bg");
            _titleLbl = (GTextField)GetChild("titleLbl");
            _titleNum = (GTextField)GetChild("titleNum");
            _descLbl = (GTextField)GetChild("descLbl");
            _label = (MonthCardlabel1)GetChild("label");
            _label2 = (MonthCardlabel2)GetChild("label2");
            _btnClaimed = (GButton)GetChild("btnClaimed");
            _btnReward = (GButton)GetChild("btnReward");
            _BtnBuy = (GButton)GetChild("BtnBuy");
            _BtnBuy_next = (GButton)GetChild("BtnBuy_next");
        }
    }
}