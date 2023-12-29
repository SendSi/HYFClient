/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class Item_Currency : GComponent
    {
        public Controller _addCtrl;
        public GLoader _icon;
        public GTextField _hasNumTxt;
        public com_btn_null _btnItem;
        public com_btnAdd2 _btnAdd;
        public Transition _transition;
        public const string URL = "ui://2r331opvd37l1ygcfhi";

        public static Item_Currency CreateInstance()
        {
            return (Item_Currency)UIPackage.CreateObject("CommonPKG", "Item_Currency");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _addCtrl = GetController("addCtrl");
            _icon = (GLoader)GetChild("icon");
            _hasNumTxt = (GTextField)GetChild("hasNumTxt");
            _btnItem = (com_btn_null)GetChild("btnItem");
            _btnAdd = (com_btnAdd2)GetChild("btnAdd");
            _transition = GetTransition("transition");
        }
    }
}