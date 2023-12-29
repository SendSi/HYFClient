/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_btn_tab3 : GButton
    {
        public GLoader _bg;
        public const string URL = "ui://2r331opvk06chz9d3d";

        public static com_btn_tab3 CreateInstance()
        {
            return (com_btn_tab3)UIPackage.CreateObject("CommonPKG", "com_btn_tab3");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GLoader)GetChild("bg");
        }
    }
}