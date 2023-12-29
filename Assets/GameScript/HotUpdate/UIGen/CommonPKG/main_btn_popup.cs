/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class main_btn_popup : GButton
    {
        public GGraph _bg;
        public const string URL = "ui://2r331opvhfih8s";

        public static main_btn_popup CreateInstance()
        {
            return (main_btn_popup)UIPackage.CreateObject("CommonPKG", "main_btn_popup");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GGraph)GetChild("bg");
        }
    }
}