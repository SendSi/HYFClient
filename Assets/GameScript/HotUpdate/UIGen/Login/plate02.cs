/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
    public partial class plate02 : GButton
    {
        public Controller _state;
        public landItem1 _recom;
        public Transition _t0;
        public const string URL = "ui://byy9k3ghg6y72b";

        public static plate02 CreateInstance()
        {
            return (plate02)UIPackage.CreateObject("Login", "plate02");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _recom = (landItem1)GetChild("recom");
            _t0 = GetTransition("t0");
        }
    }
}