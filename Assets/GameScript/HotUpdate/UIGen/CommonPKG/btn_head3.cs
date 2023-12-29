/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class btn_head3 : GButton
    {
        public Controller _red;
        public GImage _bg;
        public GComponent _effectCut;
        public red_dot _red_2;
        public const string URL = "ui://2r331opvcz1oz9clw";

        public static btn_head3 CreateInstance()
        {
            return (btn_head3)UIPackage.CreateObject("CommonPKG", "btn_head3");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _red = GetController("red");
            _bg = (GImage)GetChild("bg");
            _effectCut = (GComponent)GetChild("effectCut");
            _red_2 = (red_dot)GetChild("red");
        }
    }
}