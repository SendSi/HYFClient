/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_btn_buy4 : GButton
    {
        public Controller _colorCtrl;
        public GTextField _price;
        public const string URL = "ui://2r331opvvvwchz9d3h";

        public static com_btn_buy4 CreateInstance()
        {
            return (com_btn_buy4)UIPackage.CreateObject("CommonPKG", "com_btn_buy4");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _colorCtrl = GetController("colorCtrl");
            _price = (GTextField)GetChild("price");
        }
    }
}