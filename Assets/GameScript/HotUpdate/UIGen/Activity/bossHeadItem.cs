/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class bossHeadItem : GButton
    {
        public Controller _state;
        public Controller _lockCtrl;
        public Controller _lev;
        public Controller _nam;
        public Controller _labe;
        public GTextField _level;
        public GImage _namebg;
        public GTextField _name;
        public GImage _label;
        public const string URL = "ui://sinorujtcvsphz9czy";

        public static bossHeadItem CreateInstance()
        {
            return (bossHeadItem)UIPackage.CreateObject("Activity", "bossHeadItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _lockCtrl = GetController("lockCtrl");
            _lev = GetController("lev");
            _nam = GetController("nam");
            _labe = GetController("labe");
            _level = (GTextField)GetChild("level");
            _namebg = (GImage)GetChild("namebg");
            _name = (GTextField)GetChild("name");
            _label = (GImage)GetChild("label");
        }
    }
}