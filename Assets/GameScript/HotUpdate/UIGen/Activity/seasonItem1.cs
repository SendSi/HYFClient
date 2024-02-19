/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class seasonItem1 : GComponent
    {
        public GTextField _title;
        public const string URL = "ui://sinorujtn4491ygcfm6";

        public static seasonItem1 CreateInstance()
        {
            return (seasonItem1)UIPackage.CreateObject("Activity", "seasonItem1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _title = (GTextField)GetChild("title");
        }
    }
}