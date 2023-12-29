/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
    public partial class clothes_btn_01 : GButton
    {
        public Controller _role;
        public Controller _state;
        public Controller _label;
        public GImage _bg_01;
        public GImage _bg_02;
        public GTextField _title_name;
        public GTextField _title_number;
        public GTextField _title_recommend;
        public GTextField _title_hot;
        public GTextField _title_busy;
        public GTextField _title_maintain;
        public GImage _rolelen9;
        public const string URL = "ui://byy9k3ghp7811d";

        public static clothes_btn_01 CreateInstance()
        {
            return (clothes_btn_01)UIPackage.CreateObject("Login", "clothes_btn_01");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _role = GetController("role");
            _state = GetController("state");
            _label = GetController("label");
            _bg_01 = (GImage)GetChild("bg_01");
            _bg_02 = (GImage)GetChild("bg_02");
            _title_name = (GTextField)GetChild("title_name");
            _title_number = (GTextField)GetChild("title_number");
            _title_recommend = (GTextField)GetChild("title_recommend");
            _title_hot = (GTextField)GetChild("title_hot");
            _title_busy = (GTextField)GetChild("title_busy");
            _title_maintain = (GTextField)GetChild("title_maintain");
            _rolelen9 = (GImage)GetChild("rolelen9");
        }
    }
}