/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_little_window1 : GButton
    {
        public GButton _closeButton;
        public const string URL = "ui://2r331opvd9gi17";

        public static com_little_window1 CreateInstance()
        {
            return (com_little_window1)UIPackage.CreateObject("CommonPKG", "com_little_window1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _closeButton = (GButton)GetChild("closeButton");
        }
    }
}