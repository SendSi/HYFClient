/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ServiceActivity
{
    public partial class dayTabItem : GButton
    {
        public Controller _state;
        public Controller _reddot;
        public GComponent _redElement;
        public GLoader _red;
        public Transition _admisson;
        public const string URL = "ui://e290e74sho401ygcfjp";

        public static dayTabItem CreateInstance()
        {
            return (dayTabItem)UIPackage.CreateObject("ServiceActivity", "dayTabItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _reddot = GetController("reddot");
            _redElement = (GComponent)GetChild("redElement");
            _red = (GLoader)GetChild("red");
            _admisson = GetTransition("admisson");
        }
    }
}