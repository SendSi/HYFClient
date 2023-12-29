/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class btn_tab3 : GButton
    {
        public Controller _red;
        public GLoader _bg;
        public red_dot _redElement;
        public const string URL = "ui://2r331opvhxd7hz9d7e";

        public static btn_tab3 CreateInstance()
        {
            return (btn_tab3)UIPackage.CreateObject("CommonPKG", "btn_tab3");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _red = GetController("red");
            _bg = (GLoader)GetChild("bg");
            _redElement = (red_dot)GetChild("redElement");
        }
    }
}