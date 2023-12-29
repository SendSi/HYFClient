/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
    public partial class start : GButton
    {
        public GImage _bg;
        public const string URL = "ui://byy9k3ghv4de2q";

        public static start CreateInstance()
        {
            return (start)UIPackage.CreateObject("Login", "start");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GImage)GetChild("bg");
        }
    }
}