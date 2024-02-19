/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class LeagueBossIllustrationView : GLabel
    {
        public GTextField _ActivityIntroductionLbl;
        public GTextField _ActivityRulesLbl;
        public GTextField _describeLbl_01;
        public GTextField _describeLbl_02;
        public GTextField _describeLbl_03;
        public ruleLbl _ruleLbl;
        public GButton _closeButton;
        public GGroup _activity;
        public const string URL = "ui://sinorujtcvsphz9d06";

        public static LeagueBossIllustrationView CreateInstance()
        {
            return (LeagueBossIllustrationView)UIPackage.CreateObject("Activity", "LeagueBossIllustrationView");
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
            _closeButton = (GButton)GetChild("closeButton");
            _activity = (GGroup)GetChild("activity");
        }
    }
}