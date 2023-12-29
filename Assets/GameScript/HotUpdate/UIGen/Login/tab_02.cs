/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
    public partial class tab_02 : GComponent
    {
        public Controller _tab;
        public btn_choose _btn_tab0;
        public btn_choose _btn_tab1;
        public btn_choose _btn_tab2;
        public const string URL = "ui://byy9k3ghg6y721";

        public static tab_02 CreateInstance()
        {
            return (tab_02)UIPackage.CreateObject("Login", "tab_02");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _tab = GetController("tab");
            _btn_tab0 = (btn_choose)GetChild("btn_tab0");
            _btn_tab1 = (btn_choose)GetChild("btn_tab1");
            _btn_tab2 = (btn_choose)GetChild("btn_tab2");
        }
    }
}