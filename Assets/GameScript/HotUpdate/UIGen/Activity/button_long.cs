/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class button_long : GButton
    {
        public Controller _state;
        public const string URL = "ui://sinorujtd2so15";

        public static button_long CreateInstance()
        {
            return (button_long)UIPackage.CreateObject("Activity", "button_long");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
        }
    }
}