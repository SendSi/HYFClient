/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ServiceActivity
{
    public partial class Lbl02 : GButton
    {
        public Controller _isIcon;
        public GTextField _nameLbl;
        public GTextField _GradeLbl;
        public GList _prop;
        public const string URL = "ui://e290e74smzrr1ygcfmp";

        public static Lbl02 CreateInstance()
        {
            return (Lbl02)UIPackage.CreateObject("ServiceActivity", "Lbl02");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _isIcon = GetController("isIcon");
            _nameLbl = (GTextField)GetChild("nameLbl");
            _GradeLbl = (GTextField)GetChild("GradeLbl");
            _prop = (GList)GetChild("prop");
        }
    }
}