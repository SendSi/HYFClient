/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GuidePKG
{
    public partial class guideMask1 : GComponent
    {
        public GGraph _mask;
        public guide_efx_circle _kuang;
        public GGraph _window;
        public const string URL = "ui://vypq82a1gyzyd";

        public static guideMask1 CreateInstance()
        {
            return (guideMask1)UIPackage.CreateObject("GuidePKG", "guideMask1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GGraph)GetChild("mask");
            _kuang = (guide_efx_circle)GetChild("kuang");
            _window = (GGraph)GetChild("window");
        }
    }
}