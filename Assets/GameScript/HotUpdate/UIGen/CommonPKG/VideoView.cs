/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class VideoView : GComponent
    {
        public GGraph _bg;
        public GLoader _videoContent;
        public GButton _closeBtn;
        public const string URL = "ui://2r331opvt54x1ygcgry";

        public static VideoView CreateInstance()
        {
            return (VideoView)UIPackage.CreateObject("CommonPKG", "VideoView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GGraph)GetChild("bg");
            _videoContent = (GLoader)GetChild("videoContent");
            _closeBtn = (GButton)GetChild("closeBtn");
        }
    }
}