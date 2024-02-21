/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class DiamondItem : GButton
    {
        public Controller _stateCtrl;
        public GLoader _centerIcon;
        public GTextField _rmbLbl;
        public GTextField _numLbl;
        public GTextField _descLbl;
        public GTextField _tagTitle;
        public GGroup _tag;
        public Transition _admission;
        public const string URL = "ui://340eighf9sqn1ygcfir";

        public static DiamondItem CreateInstance()
        {
            return (DiamondItem)UIPackage.CreateObject("Welfare", "DiamondItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _stateCtrl = GetController("stateCtrl");
            _centerIcon = (GLoader)GetChild("centerIcon");
            _rmbLbl = (GTextField)GetChild("rmbLbl");
            _numLbl = (GTextField)GetChild("numLbl");
            _descLbl = (GTextField)GetChild("descLbl");
            _tagTitle = (GTextField)GetChild("tagTitle");
            _tag = (GGroup)GetChild("tag");
            _admission = GetTransition("admission");
        }
    }
}