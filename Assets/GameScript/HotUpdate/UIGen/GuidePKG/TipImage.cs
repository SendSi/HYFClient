/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GuidePKG
{
    public partial class TipImage : GComponent
    {
        public GComponent _spine;
        public GLoader _image;
        public const string URL = "ui://vypq82a1gyzyb";

        public static TipImage CreateInstance()
        {
            return (TipImage)UIPackage.CreateObject("GuidePKG", "TipImage");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _spine = (GComponent)GetChild("spine");
            _image = (GLoader)GetChild("image");
        }
    }
}