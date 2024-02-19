/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class seasonBtn2Fold : GButton
    {
        public GLoader _arrow;
        public const string URL = "ui://sinorujtt8811ygcfmh";

        public static seasonBtn2Fold CreateInstance()
        {
            return (seasonBtn2Fold)UIPackage.CreateObject("Activity", "seasonBtn2Fold");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _arrow = (GLoader)GetChild("arrow");
        }
    }
}