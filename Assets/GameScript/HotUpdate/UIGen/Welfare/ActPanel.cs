/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class ActPanel : GComponent
    {
        public Controller _tab;
        public GGraph _panel;
        public const string URL = "ui://340eighfc4bb1ygcft9";

        public static ActPanel CreateInstance()
        {
            return (ActPanel)UIPackage.CreateObject("Welfare", "ActPanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _tab = GetController("tab");
            _panel = (GGraph)GetChild("panel");
        }
    }
}