/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_little_window2 : GButton
    {
        public GButton _closeButton;
        public const string URL = "ui://2r331opvgqih1ygcfgk";

        public static com_little_window2 CreateInstance()
        {
            return (com_little_window2)UIPackage.CreateObject("CommonPKG", "com_little_window2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _closeButton = (GButton)GetChild("closeButton");
        }
    }
}