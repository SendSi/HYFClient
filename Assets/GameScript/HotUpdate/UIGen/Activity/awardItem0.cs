/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class awardItem0 : GComponent
    {
        public GTextField _num;
        public GList _icon_list;
        public const string URL = "ui://sinorujtg6ichz9cz6";

        public static awardItem0 CreateInstance()
        {
            return (awardItem0)UIPackage.CreateObject("Activity", "awardItem0");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _num = (GTextField)GetChild("num");
            _icon_list = (GList)GetChild("icon_list");
        }
    }
}