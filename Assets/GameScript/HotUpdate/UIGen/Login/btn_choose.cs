/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
    public partial class btn_choose : GButton
    {
        public Controller _race_bg;
        public Controller _gender;
        public GLoader _bg;
        public GLoader _head;
        public GTextField _title01;
        public GTextField _title02;
        public GTextField _title03;
        public GLoader _select;
        public const string URL = "ui://byy9k3ghp7811r";

        public static btn_choose CreateInstance()
        {
            return (btn_choose)UIPackage.CreateObject("Login", "btn_choose");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _race_bg = GetController("race_bg");
            _gender = GetController("gender");
            _bg = (GLoader)GetChild("bg");
            _head = (GLoader)GetChild("head");
            _title01 = (GTextField)GetChild("title01");
            _title02 = (GTextField)GetChild("title02");
            _title03 = (GTextField)GetChild("title03");
            _select = (GLoader)GetChild("select");
        }
    }
}