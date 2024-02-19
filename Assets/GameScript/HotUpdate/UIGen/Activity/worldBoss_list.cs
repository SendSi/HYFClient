/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class worldBoss_list : GComponent
    {
        public GButton _neglectBtn;
        public GButton _helpBtn;
        public GButton _headp;
        public GTextField _title;
        public GTextField _lvnum;
        public GTextField _bossname;
        public GTextField _teamnum;
        public GTextField _bloodvol;
        public const string URL = "ui://sinorujtgr021ygcfg3";

        public static worldBoss_list CreateInstance()
        {
            return (worldBoss_list)UIPackage.CreateObject("Activity", "worldBoss_list");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _neglectBtn = (GButton)GetChild("neglectBtn");
            _helpBtn = (GButton)GetChild("helpBtn");
            _headp = (GButton)GetChild("headp");
            _title = (GTextField)GetChild("title");
            _lvnum = (GTextField)GetChild("lvnum");
            _bossname = (GTextField)GetChild("bossname");
            _teamnum = (GTextField)GetChild("teamnum");
            _bloodvol = (GTextField)GetChild("bloodvol");
        }
    }
}