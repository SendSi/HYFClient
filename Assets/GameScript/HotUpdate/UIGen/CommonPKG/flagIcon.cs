/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class flagIcon : GButton
    {
        public Controller _bgColor;
        public Controller _flagColor;
        public Controller _bgIcon;
        public Controller _state;
        public GLoader _bgBig;
        public GLoader _bgSmall;
        public GLoader _flagIcon;
        public GLoader _base_colour;
        public const string URL = "ui://2r331opv6kgt1ygcflj";

        public static flagIcon CreateInstance()
        {
            return (flagIcon)UIPackage.CreateObject("CommonPKG", "flagIcon");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bgColor = GetController("bgColor");
            _flagColor = GetController("flagColor");
            _bgIcon = GetController("bgIcon");
            _state = GetController("state");
            _bgBig = (GLoader)GetChild("bgBig");
            _bgSmall = (GLoader)GetChild("bgSmall");
            _flagIcon = (GLoader)GetChild("flagIcon");
            _base_colour = (GLoader)GetChild("base_colour");
        }
    }
}