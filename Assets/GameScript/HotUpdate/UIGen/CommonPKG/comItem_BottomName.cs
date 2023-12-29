/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class comItem_BottomName : GComponent
    {
        public Controller _qualityCtrl;
        public comItem _comItem;
        public GTextField _itemName;
        public const string URL = "ui://2r331opvr52r1ygcgpe";

        public static comItem_BottomName CreateInstance()
        {
            return (comItem_BottomName)UIPackage.CreateObject("CommonPKG", "comItem_BottomName");
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