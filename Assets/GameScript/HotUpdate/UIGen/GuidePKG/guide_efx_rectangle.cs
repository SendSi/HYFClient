/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GuidePKG
{
    public partial class guide_efx_rectangle : GComponent
    {
        public Transition _t0;
        public const string URL = "ui://vypq82a1obro1m";

        public static guide_efx_rectangle CreateInstance()
        {
            return (guide_efx_rectangle)UIPackage.CreateObject("GuidePKG", "guide_efx_rectangle");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _t0 = GetTransition("t0");
        }
    }
}