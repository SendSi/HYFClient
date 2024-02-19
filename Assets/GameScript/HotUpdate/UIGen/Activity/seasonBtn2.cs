/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class seasonBtn2 : GButton
    {
        public Controller _expanded;
        public seasonBtn2Fold _arrow;
        public const string URL = "ui://sinorujtx5ob1ygcfmb";

        public static seasonBtn2 CreateInstance()
        {
            return (seasonBtn2)UIPackage.CreateObject("Activity", "seasonBtn2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _expanded = GetController("expanded");
            _arrow = (seasonBtn2Fold)GetChild("arrow");
        }
    }
}