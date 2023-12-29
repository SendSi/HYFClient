/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_btn_01 : GButton
    {
        public Controller _red;
        public red_dot _red_2;
        public const string URL = "ui://2r331opveaahz9cob";

        public static com_btn_01 CreateInstance()
        {
            return (com_btn_01)UIPackage.CreateObject("CommonPKG", "com_btn_01");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _red = GetController("red");
            _red_2 = (red_dot)GetChild("red");
        }
    }
}