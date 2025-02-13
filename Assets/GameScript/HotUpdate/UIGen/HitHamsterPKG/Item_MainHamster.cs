/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace HitHamsterPKG
{
    public partial class Item_MainHamster : GComponent
    {
        public Controller _button;
        public GImage _bottomBg;
        public Item_MaskHamster _hamster;
        public GImage _bottomBg2;
        public GGraph _hit;
        public GTextField _scoreText;
        public Transition _TrScore;
        public const string URL = "ui://q0kdbd65ntf2eaf";

        public static Item_MainHamster CreateInstance()
        {
            return (Item_MainHamster)UIPackage.CreateObject("HitHamsterPKG", "Item_MainHamster");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _button = GetController("button");
            _bottomBg = (GImage)GetChild("bottomBg");
            _hamster = (Item_MaskHamster)GetChild("hamster");
            _bottomBg2 = (GImage)GetChild("bottomBg2");
            _hit = (GGraph)GetChild("hit");
            _scoreText = (GTextField)GetChild("scoreText");
            _TrScore = GetTransition("TrScore");
        }
    }
}