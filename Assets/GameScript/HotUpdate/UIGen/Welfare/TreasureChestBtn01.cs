/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class TreasureChestBtn01 : GButton
    {
        public Controller _state;
        public GLoader _iconOpen;
        public Transition _open;
        public const string URL = "ui://340eighfhsk61ygcflq";

        public static TreasureChestBtn01 CreateInstance()
        {
            return (TreasureChestBtn01)UIPackage.CreateObject("Welfare", "TreasureChestBtn01");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _iconOpen = (GLoader)GetChild("iconOpen");
            _open = GetTransition("open");
        }
    }
}