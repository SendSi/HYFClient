/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class BreakSuccessView : GLabel
    {
        public Controller _tab;
        public GButton _bg001;
        public GImage _window;
        public GButton _btnNext;
        public GLoader3D _3d_general;
        public GComponent _beforIcon;
        public GComponent _afterIcon;
        public GList _starAttriList;
        public GTextField _tips1;
        public GGroup _star;
        public GTextField _breakTips;
        public GTextField _tips2;
        public GList _breakList;
        public GList _breakAttriList;
        public GTextField _tips4;
        public GGroup _break;
        public Transition _t0;
        public const string URL = "ui://utp01xiahe9p1ygcft7";

        public static BreakSuccessView CreateInstance()
        {
            return (BreakSuccessView)UIPackage.CreateObject("DialogTip", "BreakSuccessView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _tab = GetController("tab");
            _bg001 = (GButton)GetChild("bg001");
            _window = (GImage)GetChild("window");
            _btnNext = (GButton)GetChild("btnNext");
            _3d_general = (GLoader3D)GetChild("3d_general");
            _beforIcon = (GComponent)GetChild("beforIcon");
            _afterIcon = (GComponent)GetChild("afterIcon");
            _starAttriList = (GList)GetChild("starAttriList");
            _tips1 = (GTextField)GetChild("tips1");
            _star = (GGroup)GetChild("star");
            _breakTips = (GTextField)GetChild("breakTips");
            _tips2 = (GTextField)GetChild("tips2");
            _breakList = (GList)GetChild("breakList");
            _breakAttriList = (GList)GetChild("breakAttriList");
            _tips4 = (GTextField)GetChild("tips4");
            _break = (GGroup)GetChild("break");
            _t0 = GetTransition("t0");
        }
    }
}