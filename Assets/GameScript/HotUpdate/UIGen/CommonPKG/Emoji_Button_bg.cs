/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class Emoji_Button_bg : GButton
    {
        public GImage _bg;
        public const string URL = "ui://2r331opvdslz1l";

        public static Emoji_Button_bg CreateInstance()
        {
            return (Emoji_Button_bg)UIPackage.CreateObject("CommonPKG", "Emoji_Button_bg");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GImage)GetChild("bg");
        }
    }
}