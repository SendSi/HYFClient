/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class LimitShop_item4 : GComponent
    {
        public Controller _state;
        public GButton _headicon;
        public GTextField _nameTxt;
        public GTextField _openTxt;
        public GButton _visitBtn;
        public const string URL = "ui://340eighfcmbv1ygcfjq";

        public static LimitShop_item4 CreateInstance()
        {
            return (LimitShop_item4)UIPackage.CreateObject("Welfare", "LimitShop_item4");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _headicon = (GButton)GetChild("headicon");
            _nameTxt = (GTextField)GetChild("nameTxt");
            _openTxt = (GTextField)GetChild("openTxt");
            _visitBtn = (GButton)GetChild("visitBtn");
        }
    }
}