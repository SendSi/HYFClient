/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class skillIcon2 : GButton
    {
        public Controller _quality;
        public GLoader _bg;
        public const string URL = "ui://2r331opvo5d41qp8ve5";

        public static skillIcon2 CreateInstance()
        {
            return (skillIcon2)UIPackage.CreateObject("CommonPKG", "skillIcon2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _quality = GetController("quality");
            _bg = (GLoader)GetChild("bg");
        }
    }
}