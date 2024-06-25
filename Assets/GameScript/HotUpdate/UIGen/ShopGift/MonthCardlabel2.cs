/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ShopGift
{
    public partial class MonthCardlabel2 : GComponent
    {
        public GTextField _title;
        public const string URL = "ui://e290e74srrq31ygcfpt";

        public static MonthCardlabel2 CreateInstance()
        {
            return (MonthCardlabel2)UIPackage.CreateObject("ShopGift", "MonthCardlabel2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _title = (GTextField)GetChild("title");
        }
    }
}