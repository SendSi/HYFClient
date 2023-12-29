/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class btn_head : GButton
    {
        public Controller _red;
        public GImage _bg;
        public red_dot _red_2;
        public const string URL = "ui://2r331opvb6o0cho";

        public static btn_head CreateInstance()
        {
            return (btn_head)UIPackage.CreateObject("CommonPKG", "btn_head");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _red = GetController("red");
            _bg = (GImage)GetChild("bg");
            _red_2 = (red_dot)GetChild("red");
        }
    }
}