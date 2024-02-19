/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class customs : GComponent
    {
        public GImage _customsbg;
        public GList _customs_list;
        public const string URL = "ui://sinorujtfdrb1ygcflo";

        public static customs CreateInstance()
        {
            return (customs)UIPackage.CreateObject("Activity", "customs");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _customsbg = (GImage)GetChild("customsbg");
            _customs_list = (GList)GetChild("customs_list");
        }
    }
}