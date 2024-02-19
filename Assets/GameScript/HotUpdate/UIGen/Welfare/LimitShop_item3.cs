/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class LimitShop_item3 : GComponent
    {
        public GTextField _title;
        public GLoader _icon;
        public const string URL = "ui://340eighfcmbv1ygcfjo";

        public static LimitShop_item3 CreateInstance()
        {
            return (LimitShop_item3)UIPackage.CreateObject("Welfare", "LimitShop_item3");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _title = (GTextField)GetChild("title");
            _icon = (GLoader)GetChild("icon");
        }
    }
}