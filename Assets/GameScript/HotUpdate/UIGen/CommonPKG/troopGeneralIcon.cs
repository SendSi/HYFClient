/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class troopGeneralIcon : GComponent
    {
        public GLoader _icon;
        public const string URL = "ui://2r331opvf4o9z9cnw";

        public static troopGeneralIcon CreateInstance()
        {
            return (troopGeneralIcon)UIPackage.CreateObject("CommonPKG", "troopGeneralIcon");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _icon = (GLoader)GetChild("icon");
        }
    }
}