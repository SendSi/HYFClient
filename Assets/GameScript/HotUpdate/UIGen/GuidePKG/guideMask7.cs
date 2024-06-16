/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GuidePKG
{
    public partial class guideMask7 : GComponent
    {
        public GGraph _mask;
        public GGraph _window;
        public GImage _kuang;
        public const string URL = "ui://vypq82a1jllf26";

        public static guideMask7 CreateInstance()
        {
            return (guideMask7)UIPackage.CreateObject("GuidePKG", "guideMask7");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GGraph)GetChild("mask");
            _window = (GGraph)GetChild("window");
            _kuang = (GImage)GetChild("kuang");
        }
    }
}