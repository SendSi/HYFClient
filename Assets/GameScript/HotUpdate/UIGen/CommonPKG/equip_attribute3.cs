/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class equip_attribute3 : GButton
    {
        public Controller _color;
        public GTextField _title2;
        public const string URL = "ui://2r331opvs1351iy5b9d";

        public static equip_attribute3 CreateInstance()
        {
            return (equip_attribute3)UIPackage.CreateObject("CommonPKG", "equip_attribute3");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _color = GetController("color");
            _title2 = (GTextField)GetChild("title2");
        }
    }
}