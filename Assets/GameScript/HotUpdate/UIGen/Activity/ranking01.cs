/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class ranking01 : GComponent
    {
        public GTextField _numberlbl01;
        public GTextField _namelbl;
        public GTextField _Injurynumberlbl;
        public const string URL = "ui://sinorujtcl07hz9cyi";

        public static ranking01 CreateInstance()
        {
            return (ranking01)UIPackage.CreateObject("Activity", "ranking01");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _numberlbl01 = (GTextField)GetChild("numberlbl01");
            _namelbl = (GTextField)GetChild("namelbl");
            _Injurynumberlbl = (GTextField)GetChild("Injurynumberlbl");
        }
    }
}