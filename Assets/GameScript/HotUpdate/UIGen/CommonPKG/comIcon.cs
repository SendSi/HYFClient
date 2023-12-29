/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class comIcon : GButton
    {
        public GLoader _bg;
        public GTextField _num;
        public const string URL = "ui://2r331opvuovc1ygcfhm";

        public static comIcon CreateInstance()
        {
            return (comIcon)UIPackage.CreateObject("CommonPKG", "comIcon");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GLoader)GetChild("bg");
            _num = (GTextField)GetChild("num");
        }
    }
}