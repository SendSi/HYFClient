/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class Activity_list : GComponent
    {
        public Controller _state;
        public GButton _btnCenter;
        public GTextField _title;
        public GList _icon;
        public const string URL = "ui://sinorujtklt51iy5bbt";

        public static Activity_list CreateInstance()
        {
            return (Activity_list)UIPackage.CreateObject("Activity", "Activity_list");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _btnCenter = (GButton)GetChild("btnCenter");
            _title = (GTextField)GetChild("title");
            _icon = (GList)GetChild("icon");
        }
    }
}