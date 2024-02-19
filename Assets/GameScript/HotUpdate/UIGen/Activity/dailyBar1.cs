/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class dailyBar1 : GProgressBar
    {
        public cutDailyBar1 _mask;
        public const string URL = "ui://sinorujtwz5e1ygcfid";

        public static dailyBar1 CreateInstance()
        {
            return (dailyBar1)UIPackage.CreateObject("Activity", "dailyBar1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (cutDailyBar1)GetChild("mask");
        }
    }
}