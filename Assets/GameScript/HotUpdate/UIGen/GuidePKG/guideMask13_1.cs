/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GuidePKG
{
    public partial class guideMask13_1 : GComponent
    {
        public GGraph _mask;
        public GGraph _window;
        public const string URL = "ui://vypq82a1w2m32v";

        public static guideMask13_1 CreateInstance()
        {
            return (guideMask13_1)UIPackage.CreateObject("GuidePKG", "guideMask13_1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GGraph)GetChild("mask");
            _window = (GGraph)GetChild("window");
        }
    }
}