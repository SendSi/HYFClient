/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ServiceActivity
{
    public partial class RechargePanelView : GLabel
    {
        public rechargeItem _bg;
        public const string URL = "ui://e290e74stkvp1ygcfpj";

        public static RechargePanelView CreateInstance()
        {
            return (RechargePanelView)UIPackage.CreateObject("ServiceActivity", "RechargePanelView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (rechargeItem)GetChild("bg");
        }
    }
}