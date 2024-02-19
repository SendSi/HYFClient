/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class CalendarTipsVIew : GComponent
    {
        public Controller _state01;
        public Controller _state02;
        public GButton _closeButton;
        public GTextField _title_name;
        public GTextField _title_time;
        public GTextField _title_describe;
        public GTextField _title_Available;
        public const string URL = "ui://sinorujtw84wv";

        public static CalendarTipsVIew CreateInstance()
        {
            return (CalendarTipsVIew)UIPackage.CreateObject("Activity", "CalendarTipsVIew");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state01 = GetController("state01");
            _state02 = GetController("state02");
            _closeButton = (GButton)GetChild("closeButton");
            _title_name = (GTextField)GetChild("title_name");
            _title_time = (GTextField)GetChild("title_time");
            _title_describe = (GTextField)GetChild("title_describe");
            _title_Available = (GTextField)GetChild("title_Available");
        }
    }
}