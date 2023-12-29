/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_btn_buy2 : GButton
    {
        public GTextField _price;
        public const string URL = "ui://2r331opvnnlhhz9d15";

        public static com_btn_buy2 CreateInstance()
        {
            return (com_btn_buy2)UIPackage.CreateObject("CommonPKG", "com_btn_buy2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _price = (GTextField)GetChild("price");
        }
    }
}