/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class propsIcon : GButton
    {
        public Controller _quality;
        public GLoader _bg;
        public GTextField _number;
        public const string URL = "ui://2r331opvvvwchz9d3j";

        public static propsIcon CreateInstance()
        {
            return (propsIcon)UIPackage.CreateObject("CommonPKG", "propsIcon");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _quality = GetController("quality");
            _bg = (GLoader)GetChild("bg");
            _number = (GTextField)GetChild("number");
        }
    }
}