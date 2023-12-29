/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class main_btn3 : GButton
    {
        public Controller _red;
        public red_dot _red_2;
        public GTextField _textLbl;
        public GTextField _describeLbl;
        public Transition _scal;
        public const string URL = "ui://2r331opvya6w1ygcg9p";

        public static main_btn3 CreateInstance()
        {
            return (main_btn3)UIPackage.CreateObject("CommonPKG", "main_btn3");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _red = GetController("red");
            _red_2 = (red_dot)GetChild("red");
            _textLbl = (GTextField)GetChild("textLbl");
            _describeLbl = (GTextField)GetChild("describeLbl");
            _scal = GetTransition("scal");
        }
    }
}