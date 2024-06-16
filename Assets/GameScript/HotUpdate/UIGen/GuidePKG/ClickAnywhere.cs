/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GuidePKG
{
    public partial class ClickAnywhere : GComponent
    {
        public GGraph _clickImage;
        public const string URL = "ui://vypq82a1dgngz";

        public static ClickAnywhere CreateInstance()
        {
            return (ClickAnywhere)UIPackage.CreateObject("GuidePKG", "ClickAnywhere");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _clickImage = (GGraph)GetChild("clickImage");
        }
    }
}