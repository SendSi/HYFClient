/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class ChiefTipsVIew : GLabel
    {
        public Controller _state;
        public GImage _arrow;
        public GImage _bg01;
        public GImage _bg02;
        public GImage _bg03;
        public GLoader _chief;
        public GImage _bg04;
        public GTextField _name;
        public GTextField _name01;
        public GTextField _typelbl;
        public GTextField _typelbl01;
        public GTextField _timerlbl;
        public GButton _attack;
        public GButton _assisted;
        public GTextField _timeLbl;
        public GTextField _coordTitle;
        public const string URL = "ui://sinorujts9vk11";

        public static ChiefTipsVIew CreateInstance()
        {
            return (ChiefTipsVIew)UIPackage.CreateObject("Activity", "ChiefTipsVIew");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _arrow = (GImage)GetChild("arrow");
            _bg01 = (GImage)GetChild("bg01");
            _bg02 = (GImage)GetChild("bg02");
            _bg03 = (GImage)GetChild("bg03");
            _chief = (GLoader)GetChild("chief");
            _bg04 = (GImage)GetChild("bg04");
            _name = (GTextField)GetChild("name");
            _name01 = (GTextField)GetChild("name01");
            _typelbl = (GTextField)GetChild("typelbl");
            _typelbl01 = (GTextField)GetChild("typelbl01");
            _timerlbl = (GTextField)GetChild("timerlbl");
            _attack = (GButton)GetChild("attack");
            _assisted = (GButton)GetChild("assisted");
            _timeLbl = (GTextField)GetChild("timeLbl");
            _coordTitle = (GTextField)GetChild("coordTitle");
        }
    }
}