/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_btn_tab04 : GButton
    {
        public Controller _red;
        public Controller _display;
        public Controller _state;
        public GLoader _bg;
        public red_dot _redpoint;
        public GGroup _recommend;
        public const string URL = "ui://2r331opvprcz1qp8vfc";

        public static com_btn_tab04 CreateInstance()
        {
            return (com_btn_tab04)UIPackage.CreateObject("CommonPKG", "com_btn_tab04");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _red = GetController("red");
            _display = GetController("display");
            _state = GetController("state");
            _bg = (GLoader)GetChild("bg");
            _redpoint = (red_dot)GetChild("redpoint");
            _recommend = (GGroup)GetChild("recommend");
        }
    }
}