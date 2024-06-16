/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GuidePKG
{
    public partial class guideMask9 : GComponent
    {
        public GGraph _mask;
        public GGraph _window;
        public const string URL = "ui://vypq82a1x1i32q";

        public static guideMask9 CreateInstance()
        {
            return (guideMask9)UIPackage.CreateObject("GuidePKG", "guideMask9");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GGraph)GetChild("mask");
            _window = (GGraph)GetChild("window");
        }
    }
}