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
            _frontTop = (GGroup)GetChild("frontTop");
        }
    }
}