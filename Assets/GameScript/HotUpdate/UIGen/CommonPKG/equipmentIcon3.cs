/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class equipmentIcon3 : GButton
    {
        public Controller _quality;
        public Controller _state;
        public GGraph _indent;
        public GLoader _bg;
        public GTextField _num;
        public const string URL = "ui://2r331opvjas1hz9d80";

        public static equipmentIcon3 CreateInstance()
        {
            return (equipmentIcon3)UIPackage.CreateObject("CommonPKG", "equipmentIcon3");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _quality = GetController("quality");
            _state = GetController("state");
            _indent = (GGraph)GetChild("indent");
            _bg = (GLoader)GetChild("bg");
            _num = (GTextField)GetChild("num");
        }
    }
}