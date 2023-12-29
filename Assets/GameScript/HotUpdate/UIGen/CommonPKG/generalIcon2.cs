/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class generalIcon2 : GComponent
    {
        public Controller _reincarnation;
        public Controller _star;
        public Controller _quality;
        public GLoader _bg0;
        public GLoader _bg;
        public circleGeneral _icon;
        public GLoader _qualityIcon;
        public GTextField _lv;
        public general_star_grid _star0;
        public general_star_grid _star1;
        public general_star_grid _star2;
        public general_star_grid _star3;
        public general_star_grid _star4;
        public general_star_grid _star5;
        public general_star_grid _star6;
        public const string URL = "ui://2r331opvhxd7hz9d7b";

        public static generalIcon2 CreateInstance()
        {
            return (generalIcon2)UIPackage.CreateObject("CommonPKG", "generalIcon2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _reincarnation = GetController("reincarnation");
            _star = GetController("star");
            _quality = GetController("quality");
            _bg0 = (GLoader)GetChild("bg0");
            _bg = (GLoader)GetChild("bg");
            _icon = (circleGeneral)GetChild("icon");
            _qualityIcon = (GLoader)GetChild("qualityIcon");
            _lv = (GTextField)GetChild("lv");
            _star0 = (general_star_grid)GetChild("star0");
            _star1 = (general_star_grid)GetChild("star1");
            _star2 = (general_star_grid)GetChild("star2");
            _star3 = (general_star_grid)GetChild("star3");
            _star4 = (general_star_grid)GetChild("star4");
            _star5 = (general_star_grid)GetChild("star5");
            _star6 = (general_star_grid)GetChild("star6");
        }
    }
}