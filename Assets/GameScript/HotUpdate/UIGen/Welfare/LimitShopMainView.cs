/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class LimitShopMainView : GLabel
    {
        public Controller _state;
        public Controller _selfOtherCtrl;
        public GList _awardList;
        public GLoader _bg01;
        public GLoader _role;
        public GLoader _bg;
        public GTextField _time;
        public GButton _bookBtn;
        public LimitShop_btn1 _openBtn;
        public LimitShop_btn5 _sellBtn;
        public GButton _fairBtn;
        public GButton _explainBtn;
        public GTextField _price;
        public GTextField _num;
        public GGroup _window;
        public GComponent _Bubbling001;
        public Transition _appear;
        public const string URL = "ui://340eighfxfrq1ygcgov";

        public static LimitShopMainView CreateInstance()
        {
            return (LimitShopMainView)UIPackage.CreateObject("Welfare", "LimitShopMainView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _selfOtherCtrl = GetController("selfOtherCtrl");
            _awardList = (GList)GetChild("awardList");
            _bg01 = (GLoader)GetChild("bg01");
            _role = (GLoader)GetChild("role");
            _bg = (GLoader)GetChild("bg");
            _time = (GTextField)GetChild("time");
            _bookBtn = (GButton)GetChild("bookBtn");
            _openBtn = (LimitShop_btn1)GetChild("openBtn");
            _sellBtn = (LimitShop_btn5)GetChild("sellBtn");
            _fairBtn = (GButton)GetChild("fairBtn");
            _explainBtn = (GButton)GetChild("explainBtn");
            _price = (GTextField)GetChild("price");
            _num = (GTextField)GetChild("num");
            _window = (GGroup)GetChild("window");
            _Bubbling001 = (GComponent)GetChild("Bubbling001");
            _appear = GetTransition("appear");
        }
    }
}