/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class TreasureChestBtn : GButton
    {
        public Controller _state;
        public Controller _getState;
        public Controller _num;
        public GLoader _bg;
        public GButton _receiveBtn;
        public GTextField _describeLbl;
        public GTextField _contentLbl;
        public GTextField _numberLbl;
        public GTextField _contentLbl1;
        public GButton _returnBtn;
        public GList _list;
        public GList _itemList;
        public Transition _t0;
        public const string URL = "ui://340eighfhsk61ygcflo";

        public static TreasureChestBtn CreateInstance()
        {
            return (TreasureChestBtn)UIPackage.CreateObject("Welfare", "TreasureChestBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _getState = GetController("getState");
            _num = GetController("num");
            _bg = (GLoader)GetChild("bg");
            _receiveBtn = (GButton)GetChild("receiveBtn");
            _describeLbl = (GTextField)GetChild("describeLbl");
            _contentLbl = (GTextField)GetChild("contentLbl");
            _numberLbl = (GTextField)GetChild("numberLbl");
            _contentLbl1 = (GTextField)GetChild("contentLbl1");
            _returnBtn = (GButton)GetChild("returnBtn");
            _list = (GList)GetChild("list");
            _itemList = (GList)GetChild("itemList");
            _t0 = GetTransition("t0");
        }
    }
}