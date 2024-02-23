/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class TodayItem : GButton
    {
        public Controller _stateCtrl;
        public GLoader _bg;
        public TodayItem_Icon _traIcon;
        public GButton _receiveBtn;
        public GTextField _titleLbl;
        public GTextField _describeLbl;
        public Transition _t0;
        public const string URL = "ui://340eighfhsk61ygcflo";

        public static TodayItem CreateInstance()
        {
            return (TodayItem)UIPackage.CreateObject("Welfare", "TodayItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _stateCtrl = GetController("stateCtrl");
            _bg = (GLoader)GetChild("bg");
            _traIcon = (TodayItem_Icon)GetChild("traIcon");
            _receiveBtn = (GButton)GetChild("receiveBtn");
            _titleLbl = (GTextField)GetChild("titleLbl");
            _describeLbl = (GTextField)GetChild("describeLbl");
            _t0 = GetTransition("t0");
        }
    }
}