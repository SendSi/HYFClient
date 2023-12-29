/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class common_btn_tab3 : GButton
    {
        public red_dot _button_spot;
        public const string URL = "ui://2r331opv9232eg";

        public static common_btn_tab3 CreateInstance()
        {
            return (common_btn_tab3)UIPackage.CreateObject("CommonPKG", "common_btn_tab3");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _button_spot = (red_dot)GetChild("button_spot");
        }
    }
}