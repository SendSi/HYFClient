/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace HotPKG
{
    public partial class HFView : GComponent
    {
        public Controller _dialogCtrl;
        public GImage _bg;
        public GTextField _topDescTxt;
        public GProgressBar _slider;
        public GTextField _tips;
        public GImage _dialogBg;
        public GTextField _diaContentTxt;
        public GButton _btnSure;
        public GGroup _dia;
        public const string URL = "ui://lq16fm3bswm21ygcga0";

        public static HFView CreateInstance()
        {
            return (HFView)UIPackage.CreateObject("HotPKG", "HFView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _dialogCtrl = GetController("dialogCtrl");
            _bg = (GImage)GetChild("bg");
            _topDescTxt = (GTextField)GetChild("topDescTxt");
            _slider = (GProgressBar)GetChild("slider");
            _tips = (GTextField)GetChild("tips");
            _dialogBg = (GImage)GetChild("dialogBg");
            _diaContentTxt = (GTextField)GetChild("diaContentTxt");
            _btnSure = (GButton)GetChild("btnSure");
            _dia = (GGroup)GetChild("dia");
        }
    }
}