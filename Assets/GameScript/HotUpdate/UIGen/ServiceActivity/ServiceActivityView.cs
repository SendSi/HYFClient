/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ServiceActivity
{
    public partial class ServiceActivityView : GLabel
    {
        public Controller _state;
        public Controller _attach;
        public GLoader _bg;
        public GComponent _panel;
        public GTextField _time;
        public GButton _closeButton;
        public GList _list;
        public GComponent _illustrationBtn;
        public GGroup _left;
        public const string URL = "ui://e290e74sqx1k1ygcfnp";

        public static ServiceActivityView CreateInstance()
        {
            return (ServiceActivityView)UIPackage.CreateObject("ServiceActivity", "ServiceActivityView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _attach = GetController("attach");
            _bg = (GLoader)GetChild("bg");
            _panel = (GComponent)GetChild("panel");
            _time = (GTextField)GetChild("time");
            _closeButton = (GButton)GetChild("closeButton");
            _list = (GList)GetChild("list");
            _illustrationBtn = (GComponent)GetChild("illustrationBtn");
            _left = (GGroup)GetChild("left");
        }
    }
}