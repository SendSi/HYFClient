/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class Main_FuncTop : GButton
    {
        public Controller _redCtrl;
        public Controller _titleCtrl;
        public GButton _button_spot;
        public GTextField _title01;
        public GTextField _title02;
        public GRichTextField _title03;
        public const string URL = "ui://4ni413lagzkh8i";

        public static Main_FuncTop CreateInstance()
        {
            return (Main_FuncTop)UIPackage.CreateObject("MainCenter", "Main_FuncTop");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _redCtrl = GetController("redCtrl");
            _titleCtrl = GetController("titleCtrl");
            _button_spot = (GButton)GetChild("button_spot");
            _title01 = (GTextField)GetChild("title01");
            _title02 = (GTextField)GetChild("title02");
            _title03 = (GRichTextField)GetChild("title03");
        }
    }
}