/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class LimitShop_btn1 : GButton
    {
        public GTextField _title1;
        public GImage _btn;
        public const string URL = "ui://340eighfrjiw1ygcfj1";

        public static LimitShop_btn1 CreateInstance()
        {
            return (LimitShop_btn1)UIPackage.CreateObject("Welfare", "LimitShop_btn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _title1 = (GTextField)GetChild("title1");
            _btn = (GImage)GetChild("btn");
        }
    }
}