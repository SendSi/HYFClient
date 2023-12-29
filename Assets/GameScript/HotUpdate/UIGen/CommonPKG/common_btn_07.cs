/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class common_btn_07 : GButton
    {
        public red_dot _red;
        public const string URL = "ui://2r331opvo4uyfe";

        public static common_btn_07 CreateInstance()
        {
            return (common_btn_07)UIPackage.CreateObject("CommonPKG", "common_btn_07");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _red = (red_dot)GetChild("red");
        }
    }
}