/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GuidePKG
{
    public partial class FingerUI : GComponent
    {
        public FingerAnim _finger;
        public const string URL = "ui://vypq82a1lz3y38";

        public static FingerUI CreateInstance()
        {
            return (FingerUI)UIPackage.CreateObject("GuidePKG", "FingerUI");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _finger = (FingerAnim)GetChild("finger");
        }
    }
}