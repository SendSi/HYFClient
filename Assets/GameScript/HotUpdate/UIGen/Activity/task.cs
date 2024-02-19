/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class task : GComponent
    {
        public Controller _state;
        public GLoader _icon;
        public GTextField _title;
        public GTextField _ordinaryLbl01;
        public GTextField _quantityLbl01;
        public GTextField _ordinaryLbl02;
        public GTextField _quantityLbl02;
        public GList _stateList;
        public GButton _goBtn;
        public GButton _buyBtn;
        public GButton _noBtn;
        public const string URL = "ui://sinorujtk6h81ygcfi8";

        public static task CreateInstance()
        {
            return (task)UIPackage.CreateObject("Activity", "task");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _icon = (GLoader)GetChild("icon");
            _title = (GTextField)GetChild("title");
            _ordinaryLbl01 = (GTextField)GetChild("ordinaryLbl01");
            _quantityLbl01 = (GTextField)GetChild("quantityLbl01");
            _ordinaryLbl02 = (GTextField)GetChild("ordinaryLbl02");
            _quantityLbl02 = (GTextField)GetChild("quantityLbl02");
            _stateList = (GList)GetChild("stateList");
            _goBtn = (GButton)GetChild("goBtn");
            _buyBtn = (GButton)GetChild("buyBtn");
            _noBtn = (GButton)GetChild("noBtn");
        }
    }
}