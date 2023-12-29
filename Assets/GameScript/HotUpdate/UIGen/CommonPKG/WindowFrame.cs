/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class WindowFrame : GLabel
    {
        public GButton _closeButton;
        public const string URL = "ui://2r331opvhdmy1iy5b95";

        public static WindowFrame CreateInstance()
        {
            return (WindowFrame)UIPackage.CreateObject("CommonPKG", "WindowFrame");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _closeButton = (GButton)GetChild("closeButton");
        }
    }
}