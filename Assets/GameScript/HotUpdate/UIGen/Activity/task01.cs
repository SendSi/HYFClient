/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class task01 : GComponent
    {
        public Controller _state;
        public GTextField _title001;
        public const string URL = "ui://sinorujtk6h81ygcfi9";

        public static task01 CreateInstance()
        {
            return (task01)UIPackage.CreateObject("Activity", "task01");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _title001 = (GTextField)GetChild("title001");
        }
    }
}