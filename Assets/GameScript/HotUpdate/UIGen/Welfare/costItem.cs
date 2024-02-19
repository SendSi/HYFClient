/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class costItem : GComponent
    {
        public GLoader _icon;
        public GTextField _price;
        public const string URL = "ui://340eighfdy2k1ygcflx";

        public static costItem CreateInstance()
        {
            return (costItem)UIPackage.CreateObject("Welfare", "costItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _icon = (GLoader)GetChild("icon");
            _price = (GTextField)GetChild("price");
        }
    }
}