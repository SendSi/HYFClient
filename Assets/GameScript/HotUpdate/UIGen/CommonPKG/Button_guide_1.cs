/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class Button_guide_1 : GButton
    {
        public GImage _bg_00;
        public GImage _bg_01;
        public GImage _bg;
        public Transition _guide;
        public const string URL = "ui://2r331opvl3xgz9cm1";

        public static Button_guide_1 CreateInstance()
        {
            return (Button_guide_1)UIPackage.CreateObject("CommonPKG", "Button_guide_1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg_00 = (GImage)GetChild("bg_00");
            _bg_01 = (GImage)GetChild("bg_01");
            _bg = (GImage)GetChild("bg");
            _guide = GetTransition("guide");
        }
    }
}