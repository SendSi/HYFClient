/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Bag
{
    public partial class bagComposeItem : GButton
    {
        public GLoader _bg_quality;
        public GLoader _icon_prop;
        public GTextField _composeNumber;
        public GTextField _name;
        public const string URL = "ui://b7676vbq9232p";

        public static bagComposeItem CreateInstance()
        {
            return (bagComposeItem)UIPackage.CreateObject("Bag", "bagComposeItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg_quality = (GLoader)GetChild("bg_quality");
            _icon_prop = (GLoader)GetChild("icon_prop");
            _composeNumber = (GTextField)GetChild("composeNumber");
            _name = (GTextField)GetChild("name");
        }
    }
}