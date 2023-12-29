/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
    public partial class fold : GButton
    {
        public GImage _bg;
        public const string URL = "ui://byy9k3ghtc38r";

        public static fold CreateInstance()
        {
            return (fold)UIPackage.CreateObject("Login", "fold");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GImage)GetChild("bg");
        }
    }
}