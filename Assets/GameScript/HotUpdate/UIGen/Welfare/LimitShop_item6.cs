/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class LimitShop_item6 : GComponent
    {
        public GTextField _title;
        public const string URL = "ui://340eighfns8m1ygcfl3";

        public static LimitShop_item6 CreateInstance()
        {
            return (LimitShop_item6)UIPackage.CreateObject("Welfare", "LimitShop_item6");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _title = (GTextField)GetChild("title");
        }
    }
}