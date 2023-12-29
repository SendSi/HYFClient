/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class equipmentIcon4 : GButton
    {
        public Controller _quality;
        public Controller _redpoint;
        public GGraph _indent;
        public GLoader _bg;
        public GTextField _num;
        public GLoader _red;
        public GGroup _window;
        public const string URL = "ui://2r331opvg1sp1ygcgpm";

        public static equipmentIcon4 CreateInstance()
        {
            return (equipmentIcon4)UIPackage.CreateObject("CommonPKG", "equipmentIcon4");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _quality = GetController("quality");
            _redpoint = GetController("redpoint");
            _indent = (GGraph)GetChild("indent");
            _bg = (GLoader)GetChild("bg");
            _num = (GTextField)GetChild("num");
            _red = (GLoader)GetChild("red");
            _window = (GGroup)GetChild("window");
        }
    }
}