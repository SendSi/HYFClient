/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogCommonResultView : GLabel
    {
        public GImage _temp;
        public GComponent _mask;
        public GImage _window;
        public GComponent _EffectHandle_GongXiHuoDe;
        public GTextField _txtDesc;
        public GTextField _lable;
        public GButton _btnNext;
        public GButton _receiveBtn;
        public GButton _prop;
        public GTextField _nameLbl;
        public GTextField _describeLbl;
        public Transition _t0;
        public const string URL = "ui://utp01xiajo5i1iy5bbr";

        public static DialogCommonResultView CreateInstance()
        {
            return (DialogCommonResultView)UIPackage.CreateObject("DialogTip", "DialogCommonResultView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _temp = (GImage)GetChild("temp");
            _mask = (GComponent)GetChild("mask");
            _window = (GImage)GetChild("window");
            _EffectHandle_GongXiHuoDe = (GComponent)GetChild("EffectHandle_GongXiHuoDe");
            _txtDesc = (GTextField)GetChild("txtDesc");
            _lable = (GTextField)GetChild("lable");
            _btnNext = (GButton)GetChild("btnNext");
            _receiveBtn = (GButton)GetChild("receiveBtn");
            _prop = (GButton)GetChild("prop");
            _nameLbl = (GTextField)GetChild("nameLbl");
            _describeLbl = (GTextField)GetChild("describeLbl");
            _t0 = GetTransition("t0");
        }
    }
}