/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class activity_firstboss2 : GComponent
    {
        public Controller _state;
        public GTextField _quanfu;
        public GList _rewardList;
        public GButton _receiveBtn;
        public GButton _challengeBtn;
        public const string URL = "ui://340eighfq60q1ygcfhh";

        public static activity_firstboss2 CreateInstance()
        {
            return (activity_firstboss2)UIPackage.CreateObject("Welfare", "activity_firstboss2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _quanfu = (GTextField)GetChild("quanfu");
            _rewardList = (GList)GetChild("rewardList");
            _receiveBtn = (GButton)GetChild("receiveBtn");
            _challengeBtn = (GButton)GetChild("challengeBtn");
        }
    }
}