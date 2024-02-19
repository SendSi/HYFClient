/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class WishView : GLabel
    {
        public Controller _state;
        public welfare_Btn _wishBtn1;
        public welfare_Btn _wishBtn2;
        public welfare_Btn _wishBtn3;
        public GGroup _btn;
        public GImage _frebg;
        public GTextField _frequency;
        public GButton _tipBtn;
        public GTextField _wishTimesTxt;
        public WishCrit _crit;
        public GGroup _state0;
        public GComponent _propTopList;
        public Transition _t0;
        public Transition _t1;
        public Transition _t2;
        public Transition _t3;
        public const string URL = "ui://340eighfikk01ygcfi9";

        public static WishView CreateInstance()
        {
            return (WishView)UIPackage.CreateObject("Welfare", "WishView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _wishBtn1 = (welfare_Btn)GetChild("wishBtn1");
            _wishBtn2 = (welfare_Btn)GetChild("wishBtn2");
            _wishBtn3 = (welfare_Btn)GetChild("wishBtn3");
            _btn = (GGroup)GetChild("btn");
            _frebg = (GImage)GetChild("frebg");
            _frequency = (GTextField)GetChild("frequency");
            _tipBtn = (GButton)GetChild("tipBtn");
            _wishTimesTxt = (GTextField)GetChild("wishTimesTxt");
            _crit = (WishCrit)GetChild("crit");
            _state0 = (GGroup)GetChild("state0");
            _propTopList = (GComponent)GetChild("propTopList");
            _t0 = GetTransition("t0");
            _t1 = GetTransition("t1");
            _t2 = GetTransition("t2");
            _t3 = GetTransition("t3");
        }
    }
}