/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class rankItem1 : GComponent
    {
        public Controller _state;
        public GTextField _rank;
        public GTextField _num;
        public GLoader _icon;
        public const string URL = "ui://sinorujtw2ss1ygcfg8";

        public static rankItem1 CreateInstance()
        {
            return (rankItem1)UIPackage.CreateObject("Activity", "rankItem1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _rank = (GTextField)GetChild("rank");
            _num = (GTextField)GetChild("num");
            _icon = (GLoader)GetChild("icon");
        }
    }
}