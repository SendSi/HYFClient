/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GuidePKG
{
    public partial class guideMask13 : GComponent
    {
        public GComponent _mask;
        public GImage _window;
        public const string URL = "ui://vypq82a1cyw42y";

        public static guideMask13 CreateInstance()
        {
            return (guideMask13)UIPackage.CreateObject("GuidePKG", "guideMask13");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _window = (GImage)GetChild("window");
        }
    }
}