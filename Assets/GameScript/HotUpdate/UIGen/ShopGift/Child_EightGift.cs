/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ShopGift
{
    public partial class Child_EightGift : GComponent
    {
        public GLoader _bg;
        public Item_EightGift _day1;
        public Item_EightGift _day2;
        public Item_EightGift _day3;
        public Item_EightGift _day4;
        public Item_EightGift _day5;
        public Item_EightGift _day6;
        public Item_EightGift _day7;
        public Item_EightGift _day8;
        public GTextField _title;
        public GTextField _title1;
        public GTextField _timeText;
        public GGroup _window;
        public Transition _t0;
        public const string URL = "ui://e290e74se8ok1ygcfpf";

        public static Child_EightGift CreateInstance()
        {
            return (Child_EightGift)UIPackage.CreateObject("ShopGift", "Child_EightGift");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GLoader)GetChild("bg");
            _day1 = (Item_EightGift)GetChild("day1");
            _day2 = (Item_EightGift)GetChild("day2");
            _day3 = (Item_EightGift)GetChild("day3");
            _day4 = (Item_EightGift)GetChild("day4");
            _day5 = (Item_EightGift)GetChild("day5");
            _day6 = (Item_EightGift)GetChild("day6");
            _day7 = (Item_EightGift)GetChild("day7");
            _day8 = (Item_EightGift)GetChild("day8");
            _title = (GTextField)GetChild("title");
            _title1 = (GTextField)GetChild("title1");
            _timeText = (GTextField)GetChild("timeText");
            _window = (GGroup)GetChild("window");
            _t0 = GetTransition("t0");
        }
    }
}