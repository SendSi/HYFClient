/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class btn01 : GButton
    {
        public GTextField _check;
        public const string URL = "ui://sinorujtg6ichz9cz5";

        public static btn01 CreateInstance()
        {
            return (btn01)UIPackage.CreateObject("Activity", "btn01");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _check = (GTextField)GetChild("check");
        }
    }
}