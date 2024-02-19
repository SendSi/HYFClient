/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class LimitShopSellView : GLabel
    {
        public GButton _sellBtn;
        public GButton _btnCut;
        public GButton _btnPlus;
        public LimitShop_Slider _numberSlider;
        public GButton _closeButton;
        public GGroup _window;
        public const string URL = "ui://340eighfcmbv1ygcfjr";

        public static LimitShopSellView CreateInstance()
        {
            return (LimitShopSellView)UIPackage.CreateObject("Welfare", "LimitShopSellView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _sellBtn = (GButton)GetChild("sellBtn");
            _btnCut = (GButton)GetChild("btnCut");
            _btnPlus = (GButton)GetChild("btnPlus");
            _numberSlider = (LimitShop_Slider)GetChild("numberSlider");
            _closeButton = (GButton)GetChild("closeButton");
            _window = (GGroup)GetChild("window");
        }
    }
}