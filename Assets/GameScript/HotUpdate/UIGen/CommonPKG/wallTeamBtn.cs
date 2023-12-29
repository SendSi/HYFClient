/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class wallTeamBtn : GButton
    {
        public generalLock _lock1;
        public const string URL = "ui://2r331opvjs41hz9cw0";

        public static wallTeamBtn CreateInstance()
        {
            return (wallTeamBtn)UIPackage.CreateObject("CommonPKG", "wallTeamBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _lock1 = (generalLock)GetChild("lock1");
        }
    }
}