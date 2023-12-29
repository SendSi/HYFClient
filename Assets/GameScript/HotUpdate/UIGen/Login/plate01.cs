/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
    public partial class plate01 : GButton
    {
        public Controller _state;
        public landItem1 _recom;
        public Transition _t0;
        public const string URL = "ui://byy9k3ghg6y72a";

        public static plate01 CreateInstance()
        {
            return (plate01)UIPackage.CreateObject("Login", "plate01");
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