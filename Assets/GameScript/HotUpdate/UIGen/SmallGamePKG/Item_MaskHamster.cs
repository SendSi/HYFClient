/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SmallGamePKG
{
    public partial class Item_MaskHamster : GComponent
    {
        public Controller _stateCtrl;
        public GLoader _hit;
        public GLoader _1;
        public GLoader _2;
        public GLoader _3;
        public GLoader _4;
        public GLoader _5;
        public Transition _TrMove;
        public Transition _TrStrike;
        public Transition _TrSpeed;
        public Transition _TrKit;
        public const string URL = "ui://q0kdbd65fxl2eak";

        public static Item_MaskHamster CreateInstance()
        {
            return (Item_MaskHamster)UIPackage.CreateObject("SmallGamePKG", "Item_MaskHamster");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _stateCtrl = GetController("stateCtrl");
            _hit = (GLoader)GetChild("hit");
            _1 = (GLoader)GetChild("1");
            _2 = (GLoader)GetChild("2");
            _3 = (GLoader)GetChild("3");
            _4 = (GLoader)GetChild("4");
            _5 = (GLoader)GetChild("5");
            _TrMove = GetTransition("TrMove");
            _TrStrike = GetTransition("TrStrike");
            _TrSpeed = GetTransition("TrSpeed");
            _TrKit = GetTransition("TrKit");
        }
    }
}