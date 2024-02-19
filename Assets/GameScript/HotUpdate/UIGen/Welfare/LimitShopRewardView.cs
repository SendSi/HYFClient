/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class LimitShopRewardView : GLabel
    {
        public GTextField _descTxt;
        public GButton _awardBtn;
        public GButton _explainBtn;
        public GTextField _num;
        public GLoader _icon1;
        public GTextField _level;
        public GTextField _giftTxt;
        public GList _buildList;
        public GTextField _freshTxt;
        public GTextField _number;
        public LimitShop_box _box;
        public GButton _closeButton;
        public GGroup _window;
        public GComponent _propTopList;
        public const string URL = "ui://340eighfcmbv1ygcfj6";

        public static LimitShopRewardView CreateInstance()
        {
            return (LimitShopRewardView)UIPackage.CreateObject("Welfare", "LimitShopRewardView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _descTxt = (GTextField)GetChild("descTxt");
            _awardBtn = (GButton)GetChild("awardBtn");
            _explainBtn = (GButton)GetChild("explainBtn");
            _num = (GTextField)GetChild("num");
            _icon1 = (GLoader)GetChild("icon1");
            _level = (GTextField)GetChild("level");
            _giftTxt = (GTextField)GetChild("giftTxt");
            _buildList = (GList)GetChild("buildList");
            _freshTxt = (GTextField)GetChild("freshTxt");
            _number = (GTextField)GetChild("number");
            _box = (LimitShop_box)GetChild("box");
            _closeButton = (GButton)GetChild("closeButton");
            _window = (GGroup)GetChild("window");
            _propTopList = (GComponent)GetChild("propTopList");
        }
    }
}