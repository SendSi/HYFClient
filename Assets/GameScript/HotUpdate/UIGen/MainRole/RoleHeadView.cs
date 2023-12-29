/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainRole
{
    public partial class RoleHeadView : GComponent
    {
        public Controller _state;
        public Controller _tab;
        public Controller _label;
        public GButton _bgBtn;
        public GButton _btnModify;
        public GList _iconList;
        public GTextField _conditionLbl_01;
        public GTextField _conditionLbl_02;
        public GTextField _quantityLbl_01;
        public GTextField _quantityLbl_02;
        public GButton _tabHeadBtn;
        public GButton _tabFrameBtn;
        public GButton _showHead;
        public GTextField _txtCondition01;
        public GImage _label_bg01;
        public GTextField _title;
        public GGroup _tab_1;
        public const string URL = "ui://66sh7tc6j3xs9ph";

        public static RoleHeadView CreateInstance()
        {
            return (RoleHeadView)UIPackage.CreateObject("MainRole", "RoleHeadView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _tab = GetController("tab");
            _label = GetController("label");
            _bgBtn = (GButton)GetChild("bgBtn");
            _btnModify = (GButton)GetChild("btnModify");
            _iconList = (GList)GetChild("iconList");
            _conditionLbl_01 = (GTextField)GetChild("conditionLbl_01");
            _conditionLbl_02 = (GTextField)GetChild("conditionLbl_02");
            _quantityLbl_01 = (GTextField)GetChild("quantityLbl_01");
            _quantityLbl_02 = (GTextField)GetChild("quantityLbl_02");
            _tabHeadBtn = (GButton)GetChild("tabHeadBtn");
            _tabFrameBtn = (GButton)GetChild("tabFrameBtn");
            _showHead = (GButton)GetChild("showHead");
            _txtCondition01 = (GTextField)GetChild("txtCondition01");
            _label_bg01 = (GImage)GetChild("label_bg01");
            _title = (GTextField)GetChild("title");
            _tab_1 = (GGroup)GetChild("tab_1");
        }
    }
}