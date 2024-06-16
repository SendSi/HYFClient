/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GuidePKG
{
    public partial class guideMask8 : GComponent
    {
        public GGraph _mask;
        public GImage _kuang;
        public GImage _window;
        public const string URL = "ui://vypq82a1x1i32m";

        public static guideMask8 CreateInstance()
        {
            return (guideMask8)UIPackage.CreateObject("GuidePKG", "guideMask8");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GGraph)GetChild("mask");
            _kuang = (GImage)GetChild("kuang");
            _window = (GImage)GetChild("window");
        }
    }
}