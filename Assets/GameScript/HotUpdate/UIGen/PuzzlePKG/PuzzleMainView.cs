/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace PuzzlePKG
{
    public partial class PuzzleMainView : GComponent
    {
        public GGraph _bg;
        public GButton _closeButton;
        public GLoader _iconBg;
        public GButton _btnGoto;
        public GButton _10;
        public GButton _11;
        public GButton _12;
        public GButton _13;
        public GButton _14;
        public GButton _15;
        public GButton _20;
        public GButton _21;
        public GButton _22;
        public GButton _23;
        public GButton _24;
        public GButton _25;
        public GButton _30;
        public GButton _31;
        public GButton _32;
        public GButton _33;
        public GButton _34;
        public GButton _35;
        public GButton _40;
        public GButton _41;
        public GButton _42;
        public GButton _43;
        public GButton _44;
        public GButton _45;
        public GGroup _bgTop;
        public Item_Puzzle_TL _110;
        public Item_Puzzle_T1 _111;
        public Item_Puzzle_T2 _112;
        public Item_Puzzle_T1 _113;
        public Item_Puzzle_T2 _114;
        public Item_Puzzle_TR _115;
        public Item_Puzzle_L1 _120;
        public Item_Puzzle_C1 _121;
        public Item_Puzzle_C2 _122;
        public Item_Puzzle_C1 _123;
        public Item_Puzzle_C2 _124;
        public Item_Puzzle_R1 _125;
        public Item_Puzzle_C2 _131;
        public Item_Puzzle_C1 _132;
        public Item_Puzzle_C2 _133;
        public Item_Puzzle_C1 _134;
        public Item_Puzzle_R2 _135;
        public Item_Puzzle_BL _140;
        public Item_Puzzle_B1 _141;
        public Item_Puzzle_B2 _142;
        public Item_Puzzle_B2 _143;
        public Item_Puzzle_B2 _144;
        public Item_Puzzle_BR _145;
        public Item_Puzzle_L2 _130;
        public GGroup _frontTop;
        public const string URL = "ui://791wrm7st16bl7";

        public static PuzzleMainView CreateInstance()
        {
            return (PuzzleMainView)UIPackage.CreateObject("PuzzlePKG", "PuzzleMainView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GGraph)GetChild("bg");
            _closeButton = (GButton)GetChild("closeButton");
            _iconBg = (GLoader)GetChild("iconBg");
            _btnGoto = (GButton)GetChild("btnGoto");
            _10 = (GButton)GetChild("10");
            _11 = (GButton)GetChild("11");
            _12 = (GButton)GetChild("12");
            _13 = (GButton)GetChild("13");
            _14 = (GButton)GetChild("14");
            _15 = (GButton)GetChild("15");
            _20 = (GButton)GetChild("20");
            _21 = (GButton)GetChild("21");
            _22 = (GButton)GetChild("22");
            _23 = (GButton)GetChild("23");
            _24 = (GButton)GetChild("24");
            _25 = (GButton)GetChild("25");
            _30 = (GButton)GetChild("30");
            _31 = (GButton)GetChild("31");
            _32 = (GButton)GetChild("32");
            _33 = (GButton)GetChild("33");
            _34 = (GButton)GetChild("34");
            _35 = (GButton)GetChild("35");
            _40 = (GButton)GetChild("40");
            _41 = (GButton)GetChild("41");
            _42 = (GButton)GetChild("42");
            _43 = (GButton)GetChild("43");
            _44 = (GButton)GetChild("44");
            _45 = (GButton)GetChild("45");
            _bgTop = (GGroup)GetChild("bgTop");
            _110 = (Item_Puzzle_TL)GetChild("110");
            _111 = (Item_Puzzle_T1)GetChild("111");
            _112 = (Item_Puzzle_T2)GetChild("112");
            _113 = (Item_Puzzle_T1)GetChild("113");
            _114 = (Item_Puzzle_T2)GetChild("114");
            _115 = (Item_Puzzle_TR)GetChild("115");
            _120 = (Item_Puzzle_L1)GetChild("120");
            _121 = (Item_Puzzle_C1)GetChild("121");
            _122 = (Item_Puzzle_C2)GetChild("122");
            _123 = (Item_Puzzle_C1)GetChild("123");
            _124 = (Item_Puzzle_C2)GetChild("124");
            _125 = (Item_Puzzle_R1)GetChild("125");
            _131 = (Item_Puzzle_C2)GetChild("131");
            _132 = (Item_Puzzle_C1)GetChild("132");
            _133 = (Item_Puzzle_C2)GetChild("133");
            _134 = (Item_Puzzle_C1)GetChild("134");
            _135 = (Item_Puzzle_R2)GetChild("135");
            _140 = (Item_Puzzle_BL)GetChild("140");
            _141 = (Item_Puzzle_B1)GetChild("141");
            _142 = (Item_Puzzle_B2)GetChild("142");
            _143 = (Item_Puzzle_B2)GetChild("143");
            _144 = (Item_Puzzle_B2)GetChild("144");
            _145 = (Item_Puzzle_BR)GetChild("145");
            _130 = (Item_Puzzle_L2)GetChild("130");
            _frontTop = (GGroup)GetChild("frontTop");
        }
    }
}