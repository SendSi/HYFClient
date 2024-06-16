/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GuidePKG
{
    public partial class guideMask3 : GComponent
    {
        public GGraph _mask;
        public GGraph _window;
        public const string URL = "ui://vypq82a1nbwdj";

        public static guideMask3 CreateInstance()
        {
            return (guideMask3)UIPackage.CreateObject("GuidePKG", "guideMask3");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GGraph)GetChild("mask");
            _window = (GGraph)GetChild("window");
        }
    }
}