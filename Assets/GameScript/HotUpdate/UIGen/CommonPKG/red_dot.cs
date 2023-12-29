/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class red_dot : GButton
    {
        public Controller _title;
        public const string URL = "ui://2r331opvdix6fm";

        public static red_dot CreateInstance()
        {
            return (red_dot)UIPackage.CreateObject("CommonPKG", "red_dot");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _title = GetController("title");
        }
    }
}