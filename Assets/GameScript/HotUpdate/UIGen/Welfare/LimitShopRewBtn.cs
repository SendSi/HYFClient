/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class LimitShopRewBtn : GButton
    {
        public Controller _state;
        public GLoader _red;
        public Transition _t0;
        public const string URL = "ui://340eighfcmbvhz9cya";

        public static LimitShopRewBtn CreateInstance()
        {
            return (LimitShopRewBtn)UIPackage.CreateObject("Welfare", "LimitShopRewBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _red = (GLoader)GetChild("red");
            _t0 = GetTransition("t0");
        }
    }
}