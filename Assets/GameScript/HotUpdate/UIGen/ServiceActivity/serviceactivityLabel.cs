/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ServiceActivity
{
    public partial class serviceactivityLabel : GComponent
    {
        public GLoader _icon;
        public GTextField _title;
        public const string URL = "ui://e290e74sho401ygcfkb";

        public static serviceactivityLabel CreateInstance()
        {
            return (serviceactivityLabel)UIPackage.CreateObject("ServiceActivity", "serviceactivityLabel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _icon = (GLoader)GetChild("icon");
            _title = (GTextField)GetChild("title");
        }
    }
}