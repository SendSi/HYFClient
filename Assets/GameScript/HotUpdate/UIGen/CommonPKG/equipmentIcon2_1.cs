/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class equipmentIcon2_1 : GButton
    {
        public Controller _quality;
        public Controller _state;
        public GLoader _bg;
        public GTextField _name;
        public GTextField _lbl;
        public const string URL = "ui://2r331opvklrg1qp8vd0";

        public static equipmentIcon2_1 CreateInstance()
        {
            return (equipmentIcon2_1)UIPackage.CreateObject("CommonPKG", "equipmentIcon2_1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _quality = GetController("quality");
            _state = GetController("state");
            _bg = (GLoader)GetChild("bg");
            _name = (GTextField)GetChild("name");
            _lbl = (GTextField)GetChild("lbl");
        }
    }
}