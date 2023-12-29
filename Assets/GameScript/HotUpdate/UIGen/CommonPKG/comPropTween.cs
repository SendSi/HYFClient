/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class comPropTween : GButton
    {
        public GLoader _bg_quality;
        public const string URL = "ui://2r331opviwg4z9ckq";

        public static comPropTween CreateInstance()
        {
            return (comPropTween)UIPackage.CreateObject("CommonPKG", "comPropTween");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg_quality = (GLoader)GetChild("bg_quality");
        }
    }
}