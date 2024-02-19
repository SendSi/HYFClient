/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class ActResItem : GComponent
    {
        public Controller _ctrl;
        public GTextField _nameTxt;
        public GTextField _numTxt;
        public GList _iconList;
        public GButton _moneyBtn;
        public GButton _freeBtn;
        public GTextField _freeTxt;
        public GTextField _moneyTxt;
        public GImage _alreadyIcon;
        public const string URL = "ui://sinorujtd7a61ygcfix";

        public static ActResItem CreateInstance()
        {
            return (ActResItem)UIPackage.CreateObject("Activity", "ActResItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _ctrl = GetController("ctrl");
            _nameTxt = (GTextField)GetChild("nameTxt");
            _numTxt = (GTextField)GetChild("numTxt");
            _iconList = (GList)GetChild("iconList");
            _moneyBtn = (GButton)GetChild("moneyBtn");
            _freeBtn = (GButton)GetChild("freeBtn");
            _freeTxt = (GTextField)GetChild("freeTxt");
            _moneyTxt = (GTextField)GetChild("moneyTxt");
            _alreadyIcon = (GImage)GetChild("alreadyIcon");
        }
    }
}