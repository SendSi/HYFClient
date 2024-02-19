/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class LeagueBossSuccessView : GLabel
    {
        public GComponent _mask;
        public GButton _closeButton;
        public GImage _window;
        public GComponent _EffectHandle_GongXiHuoDe;
        public GTextField _txtDesc;
        public GTextField _rankTxt;
        public GList _ranking_list;
        public GTextField _rankinglbl;
        public GTextField _reward1;
        public GImage _horn1;
        public GList _rewardList1;
        public GTextField _reward2;
        public GList _rewardList2;
        public GTextField _tips;
        public GImage _horn2;
        public GTextField _rankinglbl2;
        public GGroup _panel;
        public const string URL = "ui://sinorujty6ps1ygcflr";

        public static LeagueBossSuccessView CreateInstance()
        {
            return (LeagueBossSuccessView)UIPackage.CreateObject("Activity", "LeagueBossSuccessView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _closeButton = (GButton)GetChild("closeButton");
            _window = (GImage)GetChild("window");
            _EffectHandle_GongXiHuoDe = (GComponent)GetChild("EffectHandle_GongXiHuoDe");
            _txtDesc = (GTextField)GetChild("txtDesc");
            _rankTxt = (GTextField)GetChild("rankTxt");
            _ranking_list = (GList)GetChild("ranking_list");
            _rankinglbl = (GTextField)GetChild("rankinglbl");
            _reward1 = (GTextField)GetChild("reward1");
            _horn1 = (GImage)GetChild("horn1");
            _rewardList1 = (GList)GetChild("rewardList1");
            _reward2 = (GTextField)GetChild("reward2");
            _rewardList2 = (GList)GetChild("rewardList2");
            _tips = (GTextField)GetChild("tips");
            _horn2 = (GImage)GetChild("horn2");
            _rankinglbl2 = (GTextField)GetChild("rankinglbl2");
            _panel = (GGroup)GetChild("panel");
        }
    }
}