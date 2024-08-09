/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SmallGamePKG
{
    public partial class sliderBar : GProgressBar
    {
        public Controller _state;
        public GImage _bg;
        public const string URL = "ui://q0kdbd65dbigemf";

        public static sliderBar CreateInstance()
        {
            return (sliderBar)UIPackage.CreateObject("SmallGamePKG", "sliderBar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _bg = (GImage)GetChild("bg");
        }
    }
}