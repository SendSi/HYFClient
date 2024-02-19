/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class LimitShop_btn5 : GButton
    {
        public GTextField _sell;
        public const string URL = "ui://340eighfrjiw1ygcfj4";

        public static LimitShop_btn5 CreateInstance()
        {
            return (LimitShop_btn5)UIPackage.CreateObject("Welfare", "LimitShop_btn5");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _sell = (GTextField)GetChild("sell");
        }
    }
}