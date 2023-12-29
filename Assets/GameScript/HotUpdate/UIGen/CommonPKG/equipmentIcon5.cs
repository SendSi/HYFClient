/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class equipmentIcon5 : GButton
    {
        public Controller _quality;
        public Controller _state;
        public GLoader _bg;
        public GTextField _lbl;
        public const string URL = "ui://2r331opvdkdi1ygcgq9";

        public static equipmentIcon5 CreateInstance()
        {
            return (equipmentIcon5)UIPackage.CreateObject("CommonPKG", "equipmentIcon5");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _quality = GetController("quality");
            _state = GetController("state");
            _bg = (GLoader)GetChild("bg");
            _lbl = (GTextField)GetChild("lbl");
        }
    }
}