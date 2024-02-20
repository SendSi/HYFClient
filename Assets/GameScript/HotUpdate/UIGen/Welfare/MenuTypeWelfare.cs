/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class MenuTypeWelfare : GComponent
    {
        public GTextField _title;
        public const string URL = "ui://340eighfdfim1ygcfpi";

        public static MenuTypeWelfare CreateInstance()
        {
            return (MenuTypeWelfare)UIPackage.CreateObject("Welfare", "MenuTypeWelfare");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _title = (GTextField)GetChild("title");
        }
    }
}