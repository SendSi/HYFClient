/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GuidePKG
{
    public partial class guideMask14 : GComponent
    {
        public GGraph _mask;
        public guide_efx_rectangle _kuang;
        public GGraph _window;
        public const string URL = "ui://vypq82a1feyt36";

        public static guideMask14 CreateInstance()
        {
            return (guideMask14)UIPackage.CreateObject("GuidePKG", "guideMask14");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GGraph)GetChild("mask");
            _kuang = (guide_efx_rectangle)GetChild("kuang");
            _window = (GGraph)GetChild("window");
        }
    }
}