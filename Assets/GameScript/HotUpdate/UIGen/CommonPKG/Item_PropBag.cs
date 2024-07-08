/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class Item_PropBag : GButton
    {
        public GImage _selectEle;
        public Item_BaseProp _baseProp;
        public const string URL = "ui://2r331opvodfq1ygcgrr";

        public static Item_PropBag CreateInstance()
        {
            return (Item_PropBag)UIPackage.CreateObject("CommonPKG", "Item_PropBag");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _selectEle = (GImage)GetChild("selectEle");
            _baseProp = (Item_BaseProp)GetChild("baseProp");
        }
    }
}