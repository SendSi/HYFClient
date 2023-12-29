/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class equip_attribute2 : GButton
    {
        public Controller _color;
        public const string URL = "ui://2r331opvs1351iy5b9c";

        public static equip_attribute2 CreateInstance()
        {
            return (equip_attribute2)UIPackage.CreateObject("CommonPKG", "equip_attribute2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _color = GetController("color");
        }
    }
}