/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class previewItem : GComponent
    {
        public GTextField _title;
        public GTextField _description;
        public GList _icon_list;
        public const string URL = "ui://sinorujtg6ichz9cz9";

        public static previewItem CreateInstance()
        {
            return (previewItem)UIPackage.CreateObject("Activity", "previewItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _title = (GTextField)GetChild("title");
            _description = (GTextField)GetChild("description");
            _icon_list = (GList)GetChild("icon_list");
        }
    }
}