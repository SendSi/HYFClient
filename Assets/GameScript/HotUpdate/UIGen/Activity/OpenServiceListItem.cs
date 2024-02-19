/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class OpenServiceListItem : GComponent
    {
        public GButton _btnCenter;
        public GTextField _title;
        public const string URL = "ui://sinorujtefo21ygcfiw";

        public static OpenServiceListItem CreateInstance()
        {
            return (OpenServiceListItem)UIPackage.CreateObject("Activity", "OpenServiceListItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _btnCenter = (GButton)GetChild("btnCenter");
            _title = (GTextField)GetChild("title");
        }
    }
}