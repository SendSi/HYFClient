/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class ChallengeMainView : GLabel
    {
        public GButton _closeButton;
        public Transition _t0;
        public const string URL = "ui://sinorujttg9h1ygcff6";

        public static ChallengeMainView CreateInstance()
        {
            return (ChallengeMainView)UIPackage.CreateObject("Activity", "ChallengeMainView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _closeButton = (GButton)GetChild("closeButton");
            _t0 = GetTransition("t0");
        }
    }
}