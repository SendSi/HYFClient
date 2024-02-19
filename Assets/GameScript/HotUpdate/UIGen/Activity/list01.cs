/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class list01 : GComponent
    {
        public GTextField _Lbl_00;
        public GTextField _Lbl_00_2;
        public GTextField _Lbl_00_3;
        public GTextField _Lbl_00_4;
        public const string URL = "ui://sinorujtcvsphz9d0b";

        public static list01 CreateInstance()
        {
            return (list01)UIPackage.CreateObject("Activity", "list01");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _Lbl_00 = (GTextField)GetChild("Lbl_00");
            _Lbl_00_2 = (GTextField)GetChild("Lbl_00");
            _Lbl_00_3 = (GTextField)GetChild("Lbl_00");
            _Lbl_00_4 = (GTextField)GetChild("Lbl_00");
        }
    }
}