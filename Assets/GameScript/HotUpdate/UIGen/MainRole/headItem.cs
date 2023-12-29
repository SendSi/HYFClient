/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainRole
{
    public partial class headItem : GButton
    {
        public Controller _state;
        public Controller _frame;
        public GGroup _headIcon;
        public GImage _state3;
        public GLoader _frame_2;
        public GGroup _stae2;
        public const string URL = "ui://66sh7tc6g38xhz9czg";

        public static headItem CreateInstance()
        {
            return (headItem)UIPackage.CreateObject("MainRole", "headItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _frame = GetController("frame");
            _headIcon = (GGroup)GetChild("headIcon");
            _state3 = (GImage)GetChild("state3");
            _frame_2 = (GLoader)GetChild("frame");
            _stae2 = (GGroup)GetChild("stae2");
        }
    }
}