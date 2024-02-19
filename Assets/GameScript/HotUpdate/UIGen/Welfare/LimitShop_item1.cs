/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class LimitShop_item1 : GComponent
    {
        public GTextField _title;
        public const string URL = "ui://340eighfcmbv1ygcfjd";

        public static LimitShop_item1 CreateInstance()
        {
            return (LimitShop_item1)UIPackage.CreateObject("Welfare", "LimitShop_item1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _title = (GTextField)GetChild("title");
        }
    }
}