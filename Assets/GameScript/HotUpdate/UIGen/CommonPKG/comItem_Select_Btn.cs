/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class comItem_Select_Btn : GButton
    {
        public Controller _qualityCtrl;
        public comItem _comItem;
        public GTextField _itemName;
        public const string URL = "ui://2r331opvabzm1ygcgnj";

        public static comItem_Select_Btn CreateInstance()
        {
            return (comItem_Select_Btn)UIPackage.CreateObject("CommonPKG", "comItem_Select_Btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _qualityCtrl = GetController("qualityCtrl");
            _comItem = (comItem)GetChild("comItem");
            _itemName = (GTextField)GetChild("itemName");
        }
    }
}