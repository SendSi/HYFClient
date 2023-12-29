/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class equipmentIcon2_2 : GButton
    {
        public Controller _quality;
        public Controller _state;
        public GLoader _bg;
        public const string URL = "ui://2r331opvgad31ygcfna";

        public static equipmentIcon2_2 CreateInstance()
        {
            return (equipmentIcon2_2)UIPackage.CreateObject("CommonPKG", "equipmentIcon2_2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _quality = GetController("quality");
            _state = GetController("state");
            _bg = (GLoader)GetChild("bg");
        }
    }
}