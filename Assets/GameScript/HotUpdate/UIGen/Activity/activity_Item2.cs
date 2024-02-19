/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class activity_Item2 : GComponent
    {
        public Controller _state;
        public GImage _bg;
        public GTextField _title;
        public GLoader _icon;
        public const string URL = "ui://sinorujts4xx1ygcfok";

        public static activity_Item2 CreateInstance()
        {
            return (activity_Item2)UIPackage.CreateObject("Activity", "activity_Item2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _bg = (GImage)GetChild("bg");
            _title = (GTextField)GetChild("title");
            _icon = (GLoader)GetChild("icon");
        }
    }
}