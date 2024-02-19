/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class activity_Item : GComponent
    {
        public Controller _state;
        public GGraph _bg;
        public GTextField _title;
        public const string URL = "ui://sinorujts4xx1ygcfoj";

        public static activity_Item CreateInstance()
        {
            return (activity_Item)UIPackage.CreateObject("Activity", "activity_Item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _bg = (GGraph)GetChild("bg");
            _title = (GTextField)GetChild("title");
        }
    }
}