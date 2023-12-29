/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class general_star_grid2 : GComponent
    {
        public Controller _button;
        public GImage _bar;
        public const string URL = "ui://2r331opv104731iy5b91";

        public static general_star_grid2 CreateInstance()
        {
            return (general_star_grid2)UIPackage.CreateObject("CommonPKG", "general_star_grid2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _button = GetController("button");
            _bar = (GImage)GetChild("bar");
        }
    }
}