/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class btn_head4 : GButton
    {
        public Controller _state;
        public Controller _frame;
        public Controller _state01;
        public GGroup _headIcon;
        public GImage _state3;
        public GLoader _frame_2;
        public GGroup _stae2;
        public const string URL = "ui://2r331opvj3xs9pm";

        public static btn_head4 CreateInstance()
        {
            return (btn_head4)UIPackage.CreateObject("CommonPKG", "btn_head4");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _frame = GetController("frame");
            _state01 = GetController("state01");
            _headIcon = (GGroup)GetChild("headIcon");
            _state3 = (GImage)GetChild("state3");
            _frame_2 = (GLoader)GetChild("frame");
            _stae2 = (GGroup)GetChild("stae2");
        }
    }
}