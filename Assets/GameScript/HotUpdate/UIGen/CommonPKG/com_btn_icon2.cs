/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_btn_icon2 : GButton
    {
        public Transition _t0;
        public const string URL = "ui://2r331opvgv9e1ygcgmr";

        public static com_btn_icon2 CreateInstance()
        {
            return (com_btn_icon2)UIPackage.CreateObject("CommonPKG", "com_btn_icon2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _t0 = GetTransition("t0");
        }
    }
}