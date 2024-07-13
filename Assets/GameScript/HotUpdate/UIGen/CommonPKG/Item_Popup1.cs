/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class Item_Popup1 : GComponent
    {
        public Controller _colorCtrl;
        public GTextField _title;
        public GTextField _itemDescTxt;
        public Item_BaseProp _comItem;
        public GGroup _content;
        public const string URL = "ui://2r331opvfipp1ygcgrx";

        public static Item_Popup1 CreateInstance()
        {
            return (Item_Popup1)UIPackage.CreateObject("CommonPKG", "Item_Popup1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _colorCtrl = GetController("colorCtrl");
            _title = (GTextField)GetChild("title");
            _itemDescTxt = (GTextField)GetChild("itemDescTxt");
            _comItem = (Item_BaseProp)GetChild("comItem");
            _content = (GGroup)GetChild("content");
        }
    }
}