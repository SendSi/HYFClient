/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GuidePKG
{
    public partial class guideMask12 : GComponent
    {
        public guideMask12_1 _mask;
        public GImage _window;
        public const string URL = "ui://vypq82a1w2m32u";

        public static guideMask12 CreateInstance()
        {
            return (guideMask12)UIPackage.CreateObject("GuidePKG", "guideMask12");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (guideMask12_1)GetChild("mask");
            _window = (GImage)GetChild("window");
        }
    }
}