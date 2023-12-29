/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Bag
{
    public partial class BagMainView : GComponent
    {
        public Controller _tabCtrl;
        public Controller _hasDataCtrl;
        public GImage _bg;
        public GTextField _title_advanced;
        public GButton _closeButton;
        public GButton _tab01;
        public GButton _tab02;
        public GButton _tab03;
        public GButton _tab04;
        public GButton _tab05;
        public GGroup _btnTab;
        public GList _propList;
        public GTextField _nothingLbl;
        public GButton _equipmentGoToBtn;
        public GButton _iconProp;
        public GTextField _titlePropTxt;
        public GTextField _descTxt;
        public GTextField _lbl01;
        public GTextField _hasTxt;
        public GButton _btnCanUsing;
        public GGroup _rightInfo;
        public GComponent _currencyList;
        public const string URL = "ui://b7676vbqxbayc";

        public static BagMainView CreateInstance()
        {
            return (BagMainView)UIPackage.CreateObject("Bag", "BagMainView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _tabCtrl = GetController("tabCtrl");
            _hasDataCtrl = GetController("hasDataCtrl");
            _bg = (GImage)GetChild("bg");
            _title_advanced = (GTextField)GetChild("title_advanced");
            _closeButton = (GButton)GetChild("closeButton");
            _tab01 = (GButton)GetChild("tab01");
            _tab02 = (GButton)GetChild("tab02");
            _tab03 = (GButton)GetChild("tab03");
            _tab04 = (GButton)GetChild("tab04");
            _tab05 = (GButton)GetChild("tab05");
            _btnTab = (GGroup)GetChild("btnTab");
            _propList = (GList)GetChild("propList");
            _nothingLbl = (GTextField)GetChild("nothingLbl");
            _equipmentGoToBtn = (GButton)GetChild("equipmentGoToBtn");
            _iconProp = (GButton)GetChild("iconProp");
            _titlePropTxt = (GTextField)GetChild("titlePropTxt");
            _descTxt = (GTextField)GetChild("descTxt");
            _lbl01 = (GTextField)GetChild("lbl01");
            _hasTxt = (GTextField)GetChild("hasTxt");
            _btnCanUsing = (GButton)GetChild("btnCanUsing");
            _rightInfo = (GGroup)GetChild("rightInfo");
            _currencyList = (GComponent)GetChild("currencyList");
        }
    }
}