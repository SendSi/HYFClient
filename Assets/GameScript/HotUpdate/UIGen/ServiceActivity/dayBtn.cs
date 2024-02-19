/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ServiceActivity
{
    public partial class dayBtn : GButton
    {
        public Controller _state;
        public GTextField _title01;
        public GTextField _title02;
        public const string URL = "ui://e290e74smzrr1ygcfmd";

        public static dayBtn CreateInstance()
        {
            return (dayBtn)UIPackage.CreateObject("ServiceActivity", "dayBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _title01 = (GTextField)GetChild("title01");
            _title02 = (GTextField)GetChild("title02");
        }
    }
}