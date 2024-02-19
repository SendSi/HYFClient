/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class btn_tab4 : GButton
    {
        public Controller _red;
        public GLoader _bg;
        public GButton _redElement;
        public const string URL = "ui://sinorujtp9k91ygcflm";

        public static btn_tab4 CreateInstance()
        {
            return (btn_tab4)UIPackage.CreateObject("Activity", "btn_tab4");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _red = GetController("red");
            _bg = (GLoader)GetChild("bg");
            _redElement = (GButton)GetChild("redElement");
        }
    }
}