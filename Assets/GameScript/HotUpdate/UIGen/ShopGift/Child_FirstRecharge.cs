/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ShopGift
{
    public partial class Child_FirstRecharge : GComponent
    {
        public rechargeItem _bg;
        public const string URL = "ui://e290e74stkvp1ygcfpj";

        public static Child_FirstRecharge CreateInstance()
        {
            return (Child_FirstRecharge)UIPackage.CreateObject("ShopGift", "Child_FirstRecharge");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (rechargeItem)GetChild("bg");
        }
    }
}