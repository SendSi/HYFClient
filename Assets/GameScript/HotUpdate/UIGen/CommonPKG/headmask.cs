/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class headmask : GComponent
    {
        public GLoader _icon;
        public const string URL = "ui://2r331opvkrfh1iy5b92";

        public static headmask CreateInstance()
        {
            return (headmask)UIPackage.CreateObject("CommonPKG", "headmask");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _icon = (GLoader)GetChild("icon");
        }
    }
}