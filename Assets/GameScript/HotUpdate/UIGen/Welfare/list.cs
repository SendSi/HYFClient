/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class list : GComponent
    {
        public GButton _propBtn;
        public GTextField _nameLbl;
        public GTextField _quantityLbl;
        public const string URL = "ui://340eighfhsk61ygcflr";

        public static list CreateInstance()
        {
            return (list)UIPackage.CreateObject("Welfare", "list");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _propBtn = (GButton)GetChild("propBtn");
            _nameLbl = (GTextField)GetChild("nameLbl");
            _quantityLbl = (GTextField)GetChild("quantityLbl");
        }
    }
}