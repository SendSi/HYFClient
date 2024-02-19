/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class seasonItem2 : GComponent
    {
        public GTextField _title;
        public const string URL = "ui://sinorujtn4491ygcfm7";

        public static seasonItem2 CreateInstance()
        {
            return (seasonItem2)UIPackage.CreateObject("Activity", "seasonItem2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _title = (GTextField)GetChild("title");
        }
    }
}