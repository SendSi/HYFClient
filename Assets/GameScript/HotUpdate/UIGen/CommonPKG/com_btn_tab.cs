/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_btn_tab : GButton
    {
        public Controller _red;
        public GTextField _title2;
        public red_dot _red_2;
        public const string URL = "ui://2r331opvc4umcio";

        public static com_btn_tab CreateInstance()
        {
            return (com_btn_tab)UIPackage.CreateObject("CommonPKG", "com_btn_tab");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _red = GetController("red");
            _title2 = (GTextField)GetChild("title2");
            _red_2 = (red_dot)GetChild("red");
        }
    }
}