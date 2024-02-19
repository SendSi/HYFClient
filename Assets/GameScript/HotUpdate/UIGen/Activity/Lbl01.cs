/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class Lbl01 : GButton
    {
        public Controller _isIcon;
        public GTextField _nameLbl;
        public GTextField _GradeLbl;
        public const string URL = "ui://sinorujtewrz1ygcfhv";

        public static Lbl01 CreateInstance()
        {
            return (Lbl01)UIPackage.CreateObject("Activity", "Lbl01");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _isIcon = GetController("isIcon");
            _nameLbl = (GTextField)GetChild("nameLbl");
            _GradeLbl = (GTextField)GetChild("GradeLbl");
        }
    }
}