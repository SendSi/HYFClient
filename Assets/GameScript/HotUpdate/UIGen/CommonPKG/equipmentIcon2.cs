/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class equipmentIcon2 : GButton
    {
        public Controller _quality;
        public Controller _state;
        public GLoader _bg;
        public GTextField _lbl;
        public const string URL = "ui://2r331opvmmv0cgy";

        public static equipmentIcon2 CreateInstance()
        {
            return (equipmentIcon2)UIPackage.CreateObject("CommonPKG", "equipmentIcon2");
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