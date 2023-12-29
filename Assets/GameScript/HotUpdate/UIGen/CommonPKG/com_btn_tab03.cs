/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_btn_tab03 : GButton
    {
        public Controller _red;
        public GLoader _bg;
        public GTextField _title0;
        public GTextField _title1;
        public red_dot _redpoint;
        public const string URL = "ui://2r331opvebe41qp8vcw";

        public static com_btn_tab03 CreateInstance()
        {
            return (com_btn_tab03)UIPackage.CreateObject("CommonPKG", "com_btn_tab03");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _red = GetController("red");
            _bg = (GLoader)GetChild("bg");
            _title0 = (GTextField)GetChild("title0");
            _title1 = (GTextField)GetChild("title1");
            _redpoint = (red_dot)GetChild("redpoint");
        }
    }
}