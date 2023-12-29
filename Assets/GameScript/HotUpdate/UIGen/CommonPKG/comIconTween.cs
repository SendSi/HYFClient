/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class comIconTween : GButton
    {
        public GImage _bg;
        public const string URL = "ui://2r331opvozu2hz9d48";

        public static comIconTween CreateInstance()
        {
            return (comIconTween)UIPackage.CreateObject("CommonPKG", "comIconTween");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GImage)GetChild("bg");
        }
    }
}