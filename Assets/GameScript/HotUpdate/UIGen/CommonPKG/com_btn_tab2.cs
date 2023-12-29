/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_btn_tab2 : GButton
    {
        public Controller _red;
        public red_dot _redDot;
        public const string URL = "ui://2r331opvz04phz9cz4";

        public static com_btn_tab2 CreateInstance()
        {
            return (com_btn_tab2)UIPackage.CreateObject("CommonPKG", "com_btn_tab2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _red = GetController("red");
            _redDot = (red_dot)GetChild("redDot");
        }
    }
}