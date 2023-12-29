/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_btn_buy1 : GButton
    {
        public Controller _change;
        public GTextField _price;
        public GTextField _pricered;
        public const string URL = "ui://2r331opvd5so1ygcfk6";

        public static com_btn_buy1 CreateInstance()
        {
            return (com_btn_buy1)UIPackage.CreateObject("CommonPKG", "com_btn_buy1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _change = GetController("change");
            _price = (GTextField)GetChild("price");
            _pricered = (GTextField)GetChild("pricered");
        }
    }
}