/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class generalIconNormal : GButton
    {
        public Controller _reincarnation;
        public Controller _quality;
        public Controller _name;
        public Controller _Arms;
        public Controller _hasCtrl;
        public GLoader _bg0;
        public GLoader _bg;
        public GLoader _qualityIcon;
        public armyBtn _armsBtn;
        public GButton _exist;
        public GTextField _nameLbl;
        public Transition _t0;
        public const string URL = "ui://2r331opvhxd7hz9d7a";

        public static generalIconNormal CreateInstance()
        {
            return (generalIconNormal)UIPackage.CreateObject("CommonPKG", "generalIconNormal");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _reincarnation = GetController("reincarnation");
            _quality = GetController("quality");
            _name = GetController("name");
            _Arms = GetController("Arms");
            _hasCtrl = GetController("hasCtrl");
            _bg0 = (GLoader)GetChild("bg0");
            _bg = (GLoader)GetChild("bg");
            _qualityIcon = (GLoader)GetChild("qualityIcon");
            _armsBtn = (armyBtn)GetChild("armsBtn");
            _exist = (GButton)GetChild("exist");
            _nameLbl = (GTextField)GetChild("nameLbl");
            _t0 = GetTransition("t0");
        }
    }
}