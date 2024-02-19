/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class LimitShop_Slider : GSlider
    {
        public GTextField _number;
        public const string URL = "ui://340eighfcmbv1ygcfl2";

        public static LimitShop_Slider CreateInstance()
        {
            return (LimitShop_Slider)UIPackage.CreateObject("Welfare", "LimitShop_Slider");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _number = (GTextField)GetChild("number");
        }
    }
}