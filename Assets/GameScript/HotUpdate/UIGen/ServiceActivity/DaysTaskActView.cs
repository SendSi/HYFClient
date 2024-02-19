/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ServiceActivity
{
    public partial class DaysTaskActView : GLabel
    {
        public GLoader _bg;
        public GTextField _pointNum;
        public GTextField _title1;
        public GList _day_tab;
        public GList _task_list;
        public GList _type_tab;
        public daysTaskAward _award;
        public GTextField _timeText;
        public GGroup _window;
        public const string URL = "ui://e290e74se8ok1ygcfpe";

        public static DaysTaskActView CreateInstance()
        {
            return (DaysTaskActView)UIPackage.CreateObject("ServiceActivity", "DaysTaskActView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GLoader)GetChild("bg");
            _pointNum = (GTextField)GetChild("pointNum");
            _title1 = (GTextField)GetChild("title1");
            _day_tab = (GList)GetChild("day_tab");
            _task_list = (GList)GetChild("task_list");
            _type_tab = (GList)GetChild("type_tab");
            _award = (daysTaskAward)GetChild("award");
            _timeText = (GTextField)GetChild("timeText");
            _window = (GGroup)GetChild("window");
        }
    }
}