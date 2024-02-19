/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class ChallengePointVIew : GComponent
    {
        public Controller _c1;
        public GButton _closeButton;
        public GTextField _secondLbl;
        public GTextField _describeLbl;
        public GButton _btnCenter;
        public const string URL = "ui://sinorujttg9hhz9d0m";

        public static ChallengePointVIew CreateInstance()
        {
            return (ChallengePointVIew)UIPackage.CreateObject("Activity", "ChallengePointVIew");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _c1 = GetController("c1");
            _closeButton = (GButton)GetChild("closeButton");
            _secondLbl = (GTextField)GetChild("secondLbl");
            _describeLbl = (GTextField)GetChild("describeLbl");
            _btnCenter = (GButton)GetChild("btnCenter");
        }
    }
}