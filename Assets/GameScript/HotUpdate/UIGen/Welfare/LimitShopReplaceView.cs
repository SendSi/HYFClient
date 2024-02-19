/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class LimitShopReplaceView : GLabel
    {
        public Controller _state;
        public GButton _retainBtn;
        public GButton _replaceBtn;
        public LimitShop_item3 _item1;
        public GImage _nameTxt;
        public LimitShop_item3 _item2;
        public GTextField _descTxt;
        public GButton _closeButton;
        public GGroup _window;
        public const string URL = "ui://340eighfcmbv1ygcfjn";

        public static LimitShopReplaceView CreateInstance()
        {
            return (LimitShopReplaceView)UIPackage.CreateObject("Welfare", "LimitShopReplaceView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _retainBtn = (GButton)GetChild("retainBtn");
            _replaceBtn = (GButton)GetChild("replaceBtn");
            _item1 = (LimitShop_item3)GetChild("item1");
            _nameTxt = (GImage)GetChild("nameTxt");
            _item2 = (LimitShop_item3)GetChild("item2");
            _descTxt = (GTextField)GetChild("descTxt");
            _closeButton = (GButton)GetChild("closeButton");
            _window = (GGroup)GetChild("window");
        }
    }
}