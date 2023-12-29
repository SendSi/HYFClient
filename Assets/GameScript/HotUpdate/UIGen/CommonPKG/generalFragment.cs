/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class generalFragment : GComponent
    {
        public GLoader _icon;
        public const string URL = "ui://2r331opvm47yhz9cnc";

        public static generalFragment CreateInstance()
        {
            return (generalFragment)UIPackage.CreateObject("CommonPKG", "generalFragment");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _icon = (GLoader)GetChild("icon");
        }
    }
}