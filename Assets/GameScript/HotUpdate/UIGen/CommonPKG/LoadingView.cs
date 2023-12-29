/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class LoadingView : GLabel
    {
        public GImage _bg;
        public GProgressBar _bar;
        public const string URL = "ui://2r331opvujpqchc";

        public static LoadingView CreateInstance()
        {
            return (LoadingView)UIPackage.CreateObject("CommonPKG", "LoadingView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GImage)GetChild("bg");
            _bar = (GProgressBar)GetChild("bar");
        }
    }
}