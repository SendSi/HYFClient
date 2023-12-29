/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class hero_bg02 : GComponent
    {
        public GImage _bg;
        public const string URL = "ui://2r331opvkvv41iy5bdz";

        public static hero_bg02 CreateInstance()
        {
            return (hero_bg02)UIPackage.CreateObject("CommonPKG", "hero_bg02");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GImage)GetChild("bg");
        }
    }
}