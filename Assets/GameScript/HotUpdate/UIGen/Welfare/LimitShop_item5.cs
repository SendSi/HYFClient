/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class LimitShop_item5 : GComponent
    {
        public GTextField _time;
        public GTextField _title;
        public GLoader _icon;
        public GTextField _number;
        public const string URL = "ui://340eighfcmbv1ygcfjs";

        public static LimitShop_item5 CreateInstance()
        {
            return (LimitShop_item5)UIPackage.CreateObject("Welfare", "LimitShop_item5");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _time = (GTextField)GetChild("time");
            _title = (GTextField)GetChild("title");
            _icon = (GLoader)GetChild("icon");
            _number = (GTextField)GetChild("number");
        }
    }
}