/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class cutDailyBar1 : GComponent
    {
        public GImage _effectMask;
        public const string URL = "ui://sinorujtqcir1ygcfn2";

        public static cutDailyBar1 CreateInstance()
        {
            return (cutDailyBar1)UIPackage.CreateObject("Activity", "cutDailyBar1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _effectMask = (GImage)GetChild("effectMask");
        }
    }
}