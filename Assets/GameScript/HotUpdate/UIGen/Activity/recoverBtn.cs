/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class recoverBtn : GButton
    {
        public Controller _red;
        public GLoader _bg;
        public GButton _redElement;
        public const string URL = "ui://sinorujtkhh61ygcfmr";

        public static recoverBtn CreateInstance()
        {
            return (recoverBtn)UIPackage.CreateObject("Activity", "recoverBtn");
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