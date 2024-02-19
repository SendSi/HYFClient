/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class activity_firstboss1 : GComponent
    {
        public Controller _state;
        public GTextField _quanfu;
        public GList _rewardList;
        public GTextField _time;
        public GTextField _name1;
        public GTextField _name2;
        public GButton _receiveBtn;
        public const string URL = "ui://340eighfq60q1ygcfhg";

        public static activity_firstboss1 CreateInstance()
        {
            return (activity_firstboss1)UIPackage.CreateObject("Welfare", "activity_firstboss1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _quanfu = (GTextField)GetChild("quanfu");
            _rewardList = (GList)GetChild("rewardList");
            _time = (GTextField)GetChild("time");
            _name1 = (GTextField)GetChild("name1");
            _name2 = (GTextField)GetChild("name2");
            _receiveBtn = (GButton)GetChild("receiveBtn");
        }
    }
}