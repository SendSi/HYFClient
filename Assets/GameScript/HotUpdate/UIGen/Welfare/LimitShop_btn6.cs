/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class LimitShop_btn6 : GButton
    {
        public GLoader _bg;
        public const string URL = "ui://340eighfrjiw1ygcfj5";

        public static LimitShop_btn6 CreateInstance()
        {
            return (LimitShop_btn6)UIPackage.CreateObject("Welfare", "LimitShop_btn6");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GLoader)GetChild("bg");
        }
    }
}