/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class btn_tab : GButton
    {
        public Controller _red;
        public red_dot _red_2;
        public const string URL = "ui://2r331opvd4a6ku";

        public static btn_tab CreateInstance()
        {
            return (btn_tab)UIPackage.CreateObject("CommonPKG", "btn_tab");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _red = GetController("red");
            _red_2 = (red_dot)GetChild("red");
        }
    }
}