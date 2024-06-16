/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GuidePKG
{
    public partial class guide_efx_rectangle0 : GComponent
    {
        public Transition _efx1;
        public Transition _efx2;
        public Transition _efx3;
        public const string URL = "ui://vypq82a1obro1n";

        public static guide_efx_rectangle0 CreateInstance()
        {
            return (guide_efx_rectangle0)UIPackage.CreateObject("GuidePKG", "guide_efx_rectangle0");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _efx1 = GetTransition("efx1");
            _efx2 = GetTransition("efx2");
            _efx3 = GetTransition("efx3");
        }
    }
}