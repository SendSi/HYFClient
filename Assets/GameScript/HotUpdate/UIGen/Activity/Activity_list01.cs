/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class Activity_list01 : GComponent
    {
        public GButton _btnCenter;
        public GLoader _icon;
        public GTextField _title;
        public const string URL = "ui://sinorujtklt51iy5bbu";

        public static Activity_list01 CreateInstance()
        {
            return (Activity_list01)UIPackage.CreateObject("Activity", "Activity_list01");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _btnCenter = (GButton)GetChild("btnCenter");
            _icon = (GLoader)GetChild("icon");
            _title = (GTextField)GetChild("title");
        }
    }
}