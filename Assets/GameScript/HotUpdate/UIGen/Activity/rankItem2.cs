/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class rankItem2 : GComponent
    {
        public GTextField _title;
        public GTextField _num;
        public const string URL = "ui://sinorujtw2ss1ygcfga";

        public static rankItem2 CreateInstance()
        {
            return (rankItem2)UIPackage.CreateObject("Activity", "rankItem2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _title = (GTextField)GetChild("title");
            _num = (GTextField)GetChild("num");
        }
    }
}