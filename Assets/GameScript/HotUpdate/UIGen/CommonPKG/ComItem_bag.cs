/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class ComItem_bag : GButton
    {
        public Controller _qualityCtrl;
        public GLoader _qualityIcon;
        public GLoader _itemIcon;
        public GImage _selectEle;
        public GTextField _hasNumTxt;
        public GGroup _iconGroup;
        public const string URL = "ui://2r331opvodfq1ygcgrr";

        public static ComItem_bag CreateInstance()
        {
            return (ComItem_bag)UIPackage.CreateObject("CommonPKG", "ComItem_bag");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _qualityCtrl = GetController("qualityCtrl");
            _qualityIcon = (GLoader)GetChild("qualityIcon");
            _itemIcon = (GLoader)GetChild("itemIcon");
            _selectEle = (GImage)GetChild("selectEle");
            _hasNumTxt = (GTextField)GetChild("hasNumTxt");
            _iconGroup = (GGroup)GetChild("iconGroup");
        }
    }
}