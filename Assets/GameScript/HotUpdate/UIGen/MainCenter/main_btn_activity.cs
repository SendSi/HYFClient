/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class main_btn_activity : GButton
    {
        public Controller _reddot;
        public Controller _state01;
        public GButton _button_spot;
        public GTextField _title01;
        public GTextField _title02;
        public GRichTextField _title03;
        public const string URL = "ui://4ni413lagzkh8i";

        public static main_btn_activity CreateInstance()
        {
            return (main_btn_activity)UIPackage.CreateObject("MainCenter", "main_btn_activity");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _reddot = GetController("reddot");
            _state01 = GetController("state01");
            _button_spot = (GButton)GetChild("button_spot");
            _title01 = (GTextField)GetChild("title01");
            _title02 = (GTextField)GetChild("title02");
            _title03 = (GRichTextField)GetChild("title03");
        }
    }
}