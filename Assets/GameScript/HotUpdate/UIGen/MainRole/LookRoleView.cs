/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainRole
{
    public partial class LookRoleView : GLabel
    {
        public GComponent _mask;
        public GComponent _bg;
        public GButton _closeButton;
        public GButton _playerIcon;
        public GTextField _nameTitle;
        public GTextField _name;
        public GTextField _leagueTitle;
        public GTextField _leagueName;
        public GTextField _capacityTitle;
        public GTextField _capacityNum;
        public GTextField _tilte01;
        public GTextField _tilte02;
        public GList _list;
        public GButton _blackBtn;
        public GButton _friendBtn;
        public GButton _delBtn;
        public const string URL = "ui://66sh7tc6z3y8hz9cz9";

        public static LookRoleView CreateInstance()
        {
            return (LookRoleView)UIPackage.CreateObject("MainRole", "LookRoleView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _bg = (GComponent)GetChild("bg");
            _closeButton = (GButton)GetChild("closeButton");
            _playerIcon = (GButton)GetChild("playerIcon");
            _nameTitle = (GTextField)GetChild("nameTitle");
            _name = (GTextField)GetChild("name");
            _leagueTitle = (GTextField)GetChild("leagueTitle");
            _leagueName = (GTextField)GetChild("leagueName");
            _capacityTitle = (GTextField)GetChild("capacityTitle");
            _capacityNum = (GTextField)GetChild("capacityNum");
            _tilte01 = (GTextField)GetChild("tilte01");
            _tilte02 = (GTextField)GetChild("tilte02");
            _list = (GList)GetChild("list");
            _blackBtn = (GButton)GetChild("blackBtn");
            _friendBtn = (GButton)GetChild("friendBtn");
            _delBtn = (GButton)GetChild("delBtn");
        }
    }
}