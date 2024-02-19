/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ServiceActivity
{
    public partial class taskAwardItem : GButton
    {
        public Controller _state;
        public Controller _select;
        public Controller _size;
        public GImage _bg1;
        public GImage _bg2;
        public GLoader _icon1;
        public Transition _scale;
        public const string URL = "ui://e290e74sho401ygcfjs";

        public static taskAwardItem CreateInstance()
        {
            return (taskAwardItem)UIPackage.CreateObject("ServiceActivity", "taskAwardItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _select = GetController("select");
            _size = GetController("size");
            _bg1 = (GImage)GetChild("bg1");
            _bg2 = (GImage)GetChild("bg2");
            _icon1 = (GLoader)GetChild("icon1");
            _scale = GetTransition("scale");
        }
    }
}