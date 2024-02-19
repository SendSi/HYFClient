/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class explainTip3 : GLabel
    {
        public GTextField _ActivityIntroductionLbl;
        public GTextField _ActivityRulesLbl;
        public GTextField _describeLbl_01;
        public GTextField _describeLbl_02;
        public GTextField _describeLbl_03;
        public ruleLbl _ruleLbl;
        public GGroup _activity;
        public const string URL = "ui://sinorujt10xg71ygcff9";

        public static explainTip3 CreateInstance()
        {
            return (explainTip3)UIPackage.CreateObject("Activity", "explainTip3");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _ActivityIntroductionLbl = (GTextField)GetChild("ActivityIntroductionLbl");
            _ActivityRulesLbl = (GTextField)GetChild("ActivityRulesLbl");
            _describeLbl_01 = (GTextField)GetChild("describeLbl_01");
            _describeLbl_02 = (GTextField)GetChild("describeLbl_02");
            _describeLbl_03 = (GTextField)GetChild("describeLbl_03");
            _ruleLbl = (ruleLbl)GetChild("ruleLbl");
            _activity = (GGroup)GetChild("activity");
        }
    }
}