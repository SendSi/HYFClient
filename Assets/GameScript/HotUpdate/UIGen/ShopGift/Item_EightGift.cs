/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ShopGift
{
    public partial class Item_EightGift : GButton
    {
        public Controller _stateCtrl;
        public Controller _rewardCtrl;
        public Controller _colorCtrl;
        public GLoader _bg;
        public GButton _icon1;
        public GButton _icon2;
        public GButton _icon3;
        public GTextField _stateTxt;
        public GTextField _stateTxt1;
        public GTextField _title1;
        public GImage _gray;
        public GGraph _mask;
        public const string URL = "ui://e290e74sfdrb1ygcfiz";

        public static Item_EightGift CreateInstance()
        {
            return (Item_EightGift)UIPackage.CreateObject("ShopGift", "Item_EightGift");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _stateCtrl = GetController("stateCtrl");
            _rewardCtrl = GetController("rewardCtrl");
            _colorCtrl = GetController("colorCtrl");
            _bg = (GLoader)GetChild("bg");
            _icon1 = (GButton)GetChild("icon1");
            _icon2 = (GButton)GetChild("icon2");
            _icon3 = (GButton)GetChild("icon3");
            _stateTxt = (GTextField)GetChild("stateTxt");
            _stateTxt1 = (GTextField)GetChild("stateTxt1");
            _title1 = (GTextField)GetChild("title1");
            _gray = (GImage)GetChild("gray");
            _mask = (GGraph)GetChild("mask");
        }
    }
}