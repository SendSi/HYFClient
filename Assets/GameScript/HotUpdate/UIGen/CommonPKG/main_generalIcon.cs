/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class main_generalIcon : GButton
    {
        public Controller _state;
        public GLoader _bg0;
        public GLoader _bg1;
        public GLoader _bg;
        public armyBtn _armsBtn;
        public Transition _t0;
        public const string URL = "ui://2r331opvsmjf1qp8vei";

        public static main_generalIcon CreateInstance()
        {
            return (main_generalIcon)UIPackage.CreateObject("CommonPKG", "main_generalIcon");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _bg0 = (GLoader)GetChild("bg0");
            _bg1 = (GLoader)GetChild("bg1");
            _bg = (GLoader)GetChild("bg");
            _armsBtn = (armyBtn)GetChild("armsBtn");
            _t0 = GetTransition("t0");
        }
    }
}