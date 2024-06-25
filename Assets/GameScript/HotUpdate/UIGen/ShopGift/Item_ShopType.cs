/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ShopGift
{
    public partial class Item_ShopType : GComponent
    {
        public GTextField _title;
        public const string URL = "ui://e290e74s11e631ygcfiu";

        public static Item_ShopType CreateInstance()
        {
            return (Item_ShopType)UIPackage.CreateObject("ShopGift", "Item_ShopType");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _title = (GTextField)GetChild("title");
        }
    }
}