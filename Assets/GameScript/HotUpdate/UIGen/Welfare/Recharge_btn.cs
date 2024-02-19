/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class Recharge_btn : GButton
    {
        public Controller _state;
        public GTextField _rmbLbl;
        public GTextField _quantityLbl;
        public GTextField _experienceLBL;
        public Transition _admission;
        public const string URL = "ui://340eighf9sqn1ygcfir";

        public static Recharge_btn CreateInstance()
        {
            return (Recharge_btn)UIPackage.CreateObject("Welfare", "Recharge_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _rmbLbl = (GTextField)GetChild("rmbLbl");
            _quantityLbl = (GTextField)GetChild("quantityLbl");
            _experienceLBL = (GTextField)GetChild("experienceLBL");
            _admission = GetTransition("admission");
        }
    }
}