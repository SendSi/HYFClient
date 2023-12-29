/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class main_teamItem : GButton
    {
        public Controller _isSelect;
        public Controller _quality;
        public Controller _star;
        public Controller _tab;
        public Controller _revive;
        public Controller _worldBoss;
        public main_teamItem0 _infor;
        public GTextField _reviveTimeLbl;
        public GGroup _reviveState;
        public GImage _attackbg;
        public GTextField _settleTimeLbl;
        public GGroup _settleState;
        public Transition _select;
        public Transition _battle;
        public const string URL = "ui://4ni413laoepthz9cpm";

        public static main_teamItem CreateInstance()
        {
            return (main_teamItem)UIPackage.CreateObject("MainCenter", "main_teamItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _isSelect = GetController("isSelect");
            _quality = GetController("quality");
            _star = GetController("star");
            _tab = GetController("tab");
            _revive = GetController("revive");
            _worldBoss = GetController("worldBoss");
            _infor = (main_teamItem0)GetChild("infor");
            _reviveTimeLbl = (GTextField)GetChild("reviveTimeLbl");
            _reviveState = (GGroup)GetChild("reviveState");
            _attackbg = (GImage)GetChild("attackbg");
            _settleTimeLbl = (GTextField)GetChild("settleTimeLbl");
            _settleState = (GGroup)GetChild("settleState");
            _select = GetTransition("select");
            _battle = GetTransition("battle");
        }
    }
}