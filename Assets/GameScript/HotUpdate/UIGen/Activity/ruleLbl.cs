/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class ruleLbl : GComponent
    {
        public GTextField _ruleLbl;
        public const string URL = "ui://sinorujtcvsphz9d07";

        public static ruleLbl CreateInstance()
        {
            return (ruleLbl)UIPackage.CreateObject("Activity", "ruleLbl");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _ruleLbl = (GTextField)GetChild("ruleLbl");
        }
    }
}