/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class PriceBtn : GButton
    {
        public Controller _buy;
        public GTextField _title01;
        public const string URL = "ui://340eighfhsk61ygcfln";

        public static PriceBtn CreateInstance()
        {
            return (PriceBtn)UIPackage.CreateObject("Welfare", "PriceBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _buy = GetController("buy");
            _title01 = (GTextField)GetChild("title01");
        }
    }
}