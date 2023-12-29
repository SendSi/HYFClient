/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class taskBtn : GButton
    {
        public GLoader _iconTwo;
        public Transition _t0;
        public const string URL = "ui://4ni413larjevhz9d2l";

        public static taskBtn CreateInstance()
        {
            return (taskBtn)UIPackage.CreateObject("MainCenter", "taskBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _iconTwo = (GLoader)GetChild("iconTwo");
            _t0 = GetTransition("t0");
        }
    }
}