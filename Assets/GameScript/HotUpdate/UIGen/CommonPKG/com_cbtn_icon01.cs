/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_cbtn_icon01 : GButton
    {
        public GTextField _quantityLbl;
        public const string URL = "ui://2r331opvklrg1qp8vcz";

        public static com_cbtn_icon01 CreateInstance()
        {
            return (com_cbtn_icon01)UIPackage.CreateObject("CommonPKG", "com_cbtn_icon01");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _quantityLbl = (GTextField)GetChild("quantityLbl");
        }
    }
}