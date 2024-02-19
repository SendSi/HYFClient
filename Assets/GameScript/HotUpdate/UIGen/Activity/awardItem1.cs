/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class awardItem1 : GComponent
    {
        public GTextField _num;
        public GList _icon_list;
        public const string URL = "ui://sinorujtg6ichz9cz4";

        public static awardItem1 CreateInstance()
        {
            return (awardItem1)UIPackage.CreateObject("Activity", "awardItem1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _num = (GTextField)GetChild("num");
            _icon_list = (GList)GetChild("icon_list");
        }
    }
}