/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
    public partial class clothes_btn_02 : GButton
    {
        public Controller _srvStateCtrl;
        public GImage _bg_01;
        public GTextField _title_number;
        public GTextField _title_area;
        public GTextField _title_change;
        public GTextField _title_hot;
        public const string URL = "ui://byy9k3ghq8mhz";

        public static clothes_btn_02 CreateInstance()
        {
            return (clothes_btn_02)UIPackage.CreateObject("Login", "clothes_btn_02");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _srvStateCtrl = GetController("srvStateCtrl");
            _bg_01 = (GImage)GetChild("bg_01");
            _title_number = (GTextField)GetChild("title_number");
            _title_area = (GTextField)GetChild("title_area");
            _title_change = (GTextField)GetChild("title_change");
            _title_hot = (GTextField)GetChild("title_hot");
        }
    }
}