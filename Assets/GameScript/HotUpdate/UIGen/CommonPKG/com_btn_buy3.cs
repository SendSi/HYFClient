/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_btn_buy3 : GButton
    {
        public Controller _enough;
        public GTextField _price;
        public const string URL = "ui://2r331opvs5edhz9d3g";

        public static com_btn_buy3 CreateInstance()
        {
            return (com_btn_buy3)UIPackage.CreateObject("CommonPKG", "com_btn_buy3");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _enough = GetController("enough");
            _price = (GTextField)GetChild("price");
        }
    }
}