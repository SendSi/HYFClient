/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class MainTopBtn : GButton
    {
        public Controller _redCtrl;
        public Controller _titleCtrl;
        public GButton _button_spot;
        public GTextField _timeTxt;
        public GTextField _willTxt;
        public const string URL = "ui://4ni413lagzkh8i";

        public static MainTopBtn CreateInstance()
        {
            return (MainTopBtn)UIPackage.CreateObject("MainCenter", "MainTopBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _redCtrl = GetController("redCtrl");
            _titleCtrl = GetController("titleCtrl");
            _button_spot = (GButton)GetChild("button_spot");
            _timeTxt = (GTextField)GetChild("timeTxt");
            _willTxt = (GTextField)GetChild("willTxt");
        }
    }
}