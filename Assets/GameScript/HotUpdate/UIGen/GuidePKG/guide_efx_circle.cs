/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GuidePKG
{
    public partial class guide_efx_circle : GComponent
    {
        public Transition _t0;
        public const string URL = "ui://vypq82a1ldlo2g";

        public static guide_efx_circle CreateInstance()
        {
            return (guide_efx_circle)UIPackage.CreateObject("GuidePKG", "guide_efx_circle");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _t0 = GetTransition("t0");
        }
    }
}