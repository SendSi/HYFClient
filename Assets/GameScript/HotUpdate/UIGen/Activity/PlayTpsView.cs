/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class PlayTpsView : GLabel
    {
        public GComponent _mask;
        public GButton _btnNext;
        public GImage _bg;
        public GTextField _rulelbl01;
        public GTextField _rulelbl02;
        public GTextField _rulelbl03;
        public GTextField _rulelbl04;
        public GTextField _rulelbl05;
        public GTextField _rulelbl;
        public GTextField _continuelbl;
        public GGroup _tips;
        public const string URL = "ui://sinorujtn41ahz9cyd";

        public static PlayTpsView CreateInstance()
        {
            return (PlayTpsView)UIPackage.CreateObject("Activity", "PlayTpsView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _btnNext = (GButton)GetChild("btnNext");
            _bg = (GImage)GetChild("bg");
            _rulelbl01 = (GTextField)GetChild("rulelbl01");
            _rulelbl02 = (GTextField)GetChild("rulelbl02");
            _rulelbl03 = (GTextField)GetChild("rulelbl03");
            _rulelbl04 = (GTextField)GetChild("rulelbl04");
            _rulelbl05 = (GTextField)GetChild("rulelbl05");
            _rulelbl = (GTextField)GetChild("rulelbl");
            _continuelbl = (GTextField)GetChild("continuelbl");
            _tips = (GGroup)GetChild("tips");
        }
    }
}