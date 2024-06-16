/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GuidePKG
{
    public partial class EnableImg : GComponent
    {
        public GGraph _clickImage;
        public const string URL = "ui://vypq82a1srlq12";

        public static EnableImg CreateInstance()
        {
            return (EnableImg)UIPackage.CreateObject("GuidePKG", "EnableImg");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _clickImage = (GGraph)GetChild("clickImage");
        }
    }
}