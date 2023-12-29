/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogPerBossView : GLabel
    {
        public GComponent _mask;
        public GButton _btnNext;
        public GButton _showTopTitle;
        public GTextField _lable;
        public GImage _window;
        public GComponent _EffectHandle_GongXiHuoDe;
        public GTextField _TimeLbl;
        public GRichTextField _DropRlbl;
        public GImage _star02;
        public GImage _star01;
        public GImage _star03;
        public GList _reward;
        public Transition _t0;
        public Transition _t1;
        public Transition _star;
        public const string URL = "ui://utp01xiaqok112";

        public static DialogPerBossView CreateInstance()
        {
            return (DialogPerBossView)UIPackage.CreateObject("DialogTip", "DialogPerBossView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _btnNext = (GButton)GetChild("btnNext");
            _showTopTitle = (GButton)GetChild("showTopTitle");
            _lable = (GTextField)GetChild("lable");
            _window = (GImage)GetChild("window");
            _EffectHandle_GongXiHuoDe = (GComponent)GetChild("EffectHandle_GongXiHuoDe");
            _TimeLbl = (GTextField)GetChild("TimeLbl");
            _DropRlbl = (GRichTextField)GetChild("DropRlbl");
            _star02 = (GImage)GetChild("star02");
            _star01 = (GImage)GetChild("star01");
            _star03 = (GImage)GetChild("star03");
            _reward = (GList)GetChild("reward");
            _t0 = GetTransition("t0");
            _t1 = GetTransition("t1");
            _star = GetTransition("star");
        }
    }
}