/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class MenuItemWelfare : GButton
    {
        public Controller _tagCtrl;
        public GLoader _label;
        public GComponent _redPoint;
        public const string URL = "ui://340eighfmqls1ygcfi8";

        public static MenuItemWelfare CreateInstance()
        {
            return (MenuItemWelfare)UIPackage.CreateObject("Welfare", "MenuItemWelfare");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _tagCtrl = GetController("tagCtrl");
            _label = (GLoader)GetChild("label");
            _redPoint = (GComponent)GetChild("redPoint");
        }
    }
}