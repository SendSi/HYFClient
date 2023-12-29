/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class generalIconBtn : GButton
    {
        public Controller _star;
        public Controller _quality;
        public GLoader _qualityBg;
        public GLoader _starBg;
        public main_teamStae _state;
        public const string URL = "ui://4ni413laxyhchz9cv9";

        public static generalIconBtn CreateInstance()
        {
            return (generalIconBtn)UIPackage.CreateObject("MainCenter", "generalIconBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _star = GetController("star");
            _quality = GetController("quality");
            _qualityBg = (GLoader)GetChild("qualityBg");
            _starBg = (GLoader)GetChild("starBg");
            _state = (main_teamStae)GetChild("state");
        }
    }
}