/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class armyBtn : GButton
    {
        public Controller _colour;
        public Controller _state;
        public Controller _state01;
        public Controller _awake;
        public GLoader _armIcon;
        public GTextField _armTitle;
        public GTextField _awakeTitle;
        public const string URL = "ui://2r331opvf3et1qp8ved";

        public static armyBtn CreateInstance()
        {
            return (armyBtn)UIPackage.CreateObject("CommonPKG", "armyBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _colour = GetController("colour");
            _state = GetController("state");
            _state01 = GetController("state01");
            _awake = GetController("awake");
            _armIcon = (GLoader)GetChild("armIcon");
            _armTitle = (GTextField)GetChild("armTitle");
            _awakeTitle = (GTextField)GetChild("awakeTitle");
        }
    }
}