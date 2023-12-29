/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_btnAdd2 : GButton
    {
        public GImage _add;
        public Transition _t0;
        public const string URL = "ui://2r331opvld4m1ygcfhr";

        public static com_btnAdd2 CreateInstance()
        {
            return (com_btnAdd2)UIPackage.CreateObject("CommonPKG", "com_btnAdd2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _add = (GImage)GetChild("add");
            _t0 = GetTransition("t0");
        }
    }
}