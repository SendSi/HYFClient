/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ServiceActivity
{
    public partial class serviceactivityItem2 : GComponent
    {
        public Controller _state;
        public GGraph _bg;
        public GLoader _icon;
        public GGraph _left;
        public GGraph _right;
        public const string URL = "ui://e290e74sho401ygcfk8";

        public static serviceactivityItem2 CreateInstance()
        {
            return (serviceactivityItem2)UIPackage.CreateObject("ServiceActivity", "serviceactivityItem2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _bg = (GGraph)GetChild("bg");
            _icon = (GLoader)GetChild("icon");
            _left = (GGraph)GetChild("left");
            _right = (GGraph)GetChild("right");
        }
    }
}