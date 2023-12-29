/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class MainCenterView : GComponent
    {
        public Controller _cityStateCtrl;
        public FuncListEles _funcListEles;
        public GImage _bottomBg;
        public main_chat_item_2 _chatBtn;
        public GButton _backBtn;
        public GButton _outBtn;
        public GList _outInList;
        public GGroup _bottomEles;
        public TopEles _topEles;
        public main_team_right _rightTeam;
        public main_taskitem _leftTask;
        public Transition _quit;
        public Transition _approach;
        public Transition _a_personalboss;
        public Transition _a_worldboss;
        public const string URL = "ui://4ni413lalumy1qp8vd6";

        public static MainCenterView CreateInstance()
        {
            return (MainCenterView)UIPackage.CreateObject("MainCenter", "MainCenterView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _cityStateCtrl = GetController("cityStateCtrl");
            _funcListEles = (FuncListEles)GetChild("funcListEles");
            _bottomBg = (GImage)GetChild("bottomBg");
            _chatBtn = (main_chat_item_2)GetChild("chatBtn");
            _backBtn = (GButton)GetChild("backBtn");
            _outBtn = (GButton)GetChild("outBtn");
            _outInList = (GList)GetChild("outInList");
            _bottomEles = (GGroup)GetChild("bottomEles");
            _topEles = (TopEles)GetChild("topEles");
            _rightTeam = (main_team_right)GetChild("rightTeam");
            _leftTask = (main_taskitem)GetChild("leftTask");
            _quit = GetTransition("quit");
            _approach = GetTransition("approach");
            _a_personalboss = GetTransition("a_personalboss");
            _a_worldboss = GetTransition("a_worldboss");
        }
    }
}