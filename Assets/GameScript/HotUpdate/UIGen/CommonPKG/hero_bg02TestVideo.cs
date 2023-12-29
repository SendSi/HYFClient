/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class hero_bg02TestVideo : GComponent
    {
        public GImage _bg;
        public GImage _site;
        public const string URL = "ui://2r331opvsz581ygcgq3";

        public static hero_bg02TestVideo CreateInstance()
        {
            return (hero_bg02TestVideo)UIPackage.CreateObject("CommonPKG", "hero_bg02TestVideo");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GImage)GetChild("bg");
            _site = (GImage)GetChild("site");
        }
    }
}