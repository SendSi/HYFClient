/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class cbtn01 : GButton
    {
        public Controller _expanded;
        public const string URL = "ui://sinorujtz3v61s";

        public static cbtn01 CreateInstance()
        {
            return (cbtn01)UIPackage.CreateObject("Activity", "cbtn01");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _expanded = GetController("expanded");
        }
    }
}