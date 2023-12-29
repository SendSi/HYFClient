/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class main_team_right : GComponent
    {
        public Controller _styleCtrl;
        public GImage _bg;
        public GList _teamList;
        public GButton _tabBtn;
        public GTextField _teamNum;
        public const string URL = "ui://4ni413lale3m1qp8vhq";

        public static main_team_right CreateInstance()
        {
            return (main_team_right)UIPackage.CreateObject("MainCenter", "main_team_right");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _styleCtrl = GetController("styleCtrl");
            _bg = (GImage)GetChild("bg");
            _teamList = (GList)GetChild("teamList");
            _tabBtn = (GButton)GetChild("tabBtn");
            _teamNum = (GTextField)GetChild("teamNum");
        }
    }
}