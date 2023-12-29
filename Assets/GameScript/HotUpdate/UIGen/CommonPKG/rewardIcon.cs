/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class rewardIcon : GButton
    {
        public Controller _quality;
        public GLoader _bg;
        public GTextField _num;
        public const string URL = "ui://2r331opvyhldk";

        public static rewardIcon CreateInstance()
        {
            return (rewardIcon)UIPackage.CreateObject("CommonPKG", "rewardIcon");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _quality = GetController("quality");
            _bg = (GLoader)GetChild("bg");
            _num = (GTextField)GetChild("num");
        }
    }
}