/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_btn_icon : GButton
    {
        public Transition _t0;
        public const string URL = "ui://2r331opvj4kdz9cp3";

        public static com_btn_icon CreateInstance()
        {
            return (com_btn_icon)UIPackage.CreateObject("CommonPKG", "com_btn_icon");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _t0 = GetTransition("t0");
        }
    }
}