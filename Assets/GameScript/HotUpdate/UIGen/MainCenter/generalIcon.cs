/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class generalIcon : GComponent
    {
        public Controller _quality;
        public Controller _star;
        public GLoader _qualityBg;
        public GLoader _starBg;
        public GComponent _icon;
        public generalIcon1 _headicon;
        public main_teamStae _state;
        public const string URL = "ui://4ni413lag9nyhz9cu0";

        public static generalIcon CreateInstance()
        {
            return (generalIcon)UIPackage.CreateObject("MainCenter", "generalIcon");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _quality = GetController("quality");
            _star = GetController("star");
            _qualityBg = (GLoader)GetChild("qualityBg");
            _starBg = (GLoader)GetChild("starBg");
            _icon = (GComponent)GetChild("icon");
            _headicon = (generalIcon1)GetChild("headicon");
            _state = (main_teamStae)GetChild("state");
        }
    }
}