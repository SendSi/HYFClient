/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class ruleItem : GComponent
    {
        public Controller _title;
        public GTextField _title_2;
        public GTextField _description;
        public const string URL = "ui://sinorujtg6ichz9cz2";

        public static ruleItem CreateInstance()
        {
            return (ruleItem)UIPackage.CreateObject("Activity", "ruleItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _title = GetController("title");
            _title_2 = (GTextField)GetChild("title");
            _description = (GTextField)GetChild("description");
        }
    }
}