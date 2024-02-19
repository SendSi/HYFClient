/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class actBtn : GButton
    {
        public GTextField _actNum;
        public GTextField _txt;
        public const string URL = "ui://sinorujtzrsshz9czg";

        public static actBtn CreateInstance()
        {
            return (actBtn)UIPackage.CreateObject("Activity", "actBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _actNum = (GTextField)GetChild("actNum");
            _txt = (GTextField)GetChild("txt");
        }
    }
}