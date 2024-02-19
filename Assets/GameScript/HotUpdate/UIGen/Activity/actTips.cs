/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class actTips : GComponent
    {
        public GTextField _txt;
        public const string URL = "ui://sinorujtzrsshz9czh";

        public static actTips CreateInstance()
        {
            return (actTips)UIPackage.CreateObject("Activity", "actTips");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _txt = (GTextField)GetChild("txt");
        }
    }
}