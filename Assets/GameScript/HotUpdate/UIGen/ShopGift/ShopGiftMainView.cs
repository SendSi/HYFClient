/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ShopGift
{
    public partial class ShopGiftMainView : GComponent
    {
        public GLoader _bg;
        public GButton _closeButton;
        public GList _leftTabList;
        public GGroup _Left;
        public const string URL = "ui://e290e74sqx1k1ygcfnp";

        public static ShopGiftMainView CreateInstance()
        {
            return (ShopGiftMainView)UIPackage.CreateObject("ShopGift", "ShopGiftMainView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GLoader)GetChild("bg");
            _closeButton = (GButton)GetChild("closeButton");
            _leftTabList = (GList)GetChild("leftTabList");
            _Left = (GGroup)GetChild("Left");
        }
    }
}