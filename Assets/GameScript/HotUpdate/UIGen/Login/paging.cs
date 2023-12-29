/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
    public partial class paging : GButton
    {
        public Controller _display;
        public GImage _bg_01;
        public GGroup _recommend;
        public const string URL = "ui://byy9k3gh7oizj";

        public static paging CreateInstance()
        {
            return (paging)UIPackage.CreateObject("Login", "paging");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _display = GetController("display");
            _bg_01 = (GImage)GetChild("bg_01");
            _recommend = (GGroup)GetChild("recommend");
        }
    }
}