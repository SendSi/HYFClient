/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogWorldBossView : GLabel
    {
        public Controller _tipCtrl;
        public Controller _btnCountCtrl;
        public GComponent _mask;
        public GButton _showTopTitle;
        public GImage _window;
        public GComponent _EffectHandle_GongXiHuoDe;
        public GTextField _txtDesc;
        public GList _ranking_list;
        public GTextField _rankinglbl;
        public GTextField _hurtLbl;
        public GImage _minebg;
        public GTextField _rankmine;
        public GTextField _friendhelp;
        public GButton _details;
        public GImage _awardbg;
        public GTextField _rewardlbl;
        public GList _reward_list;
        public GTextField _rewardlbl01;
        public GTextField _rewardlbl02;
        public GTextField _rewardlbl03;
        public GTextField _timeTip;
        public GTextField _tipsdet;
        public GGroup _com;
        public GGroup _panel;
        public GButton _confirmBtn;
        public GButton _quitBtn;
        public GButton _confirmBtn01;
        public GGroup _btn;
        public GComponent _mask1;
        public GList _rank_list;
        public GGroup _detailTip;
        public Transition _t0;
        public const string URL = "ui://utp01xiaithohz9cye";

        public static DialogWorldBossView CreateInstance()
        {
            return (DialogWorldBossView)UIPackage.CreateObject("DialogTip", "DialogWorldBossView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _tipCtrl = GetController("tipCtrl");
            _btnCountCtrl = GetController("btnCountCtrl");
            _mask = (GComponent)GetChild("mask");
            _showTopTitle = (GButton)GetChild("showTopTitle");
            _window = (GImage)GetChild("window");
            _EffectHandle_GongXiHuoDe = (GComponent)GetChild("EffectHandle_GongXiHuoDe");
            _txtDesc = (GTextField)GetChild("txtDesc");
            _ranking_list = (GList)GetChild("ranking_list");
            _rankinglbl = (GTextField)GetChild("rankinglbl");
            _hurtLbl = (GTextField)GetChild("hurtLbl");
            _minebg = (GImage)GetChild("minebg");
            _rankmine = (GTextField)GetChild("rankmine");
            _friendhelp = (GTextField)GetChild("friendhelp");
            _details = (GButton)GetChild("details");
            _awardbg = (GImage)GetChild("awardbg");
            _rewardlbl = (GTextField)GetChild("rewardlbl");
            _reward_list = (GList)GetChild("reward_list");
            _rewardlbl01 = (GTextField)GetChild("rewardlbl01");
            _rewardlbl02 = (GTextField)GetChild("rewardlbl02");
            _rewardlbl03 = (GTextField)GetChild("rewardlbl03");
            _timeTip = (GTextField)GetChild("timeTip");
            _tipsdet = (GTextField)GetChild("tipsdet");
            _com = (GGroup)GetChild("com");
            _panel = (GGroup)GetChild("panel");
            _confirmBtn = (GButton)GetChild("confirmBtn");
            _quitBtn = (GButton)GetChild("quitBtn");
            _confirmBtn01 = (GButton)GetChild("confirmBtn01");
            _btn = (GGroup)GetChild("btn");
            _mask1 = (GComponent)GetChild("mask1");
            _rank_list = (GList)GetChild("rank_list");
            _detailTip = (GGroup)GetChild("detailTip");
            _t0 = GetTransition("t0");
        }
    }
}