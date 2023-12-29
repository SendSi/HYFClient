/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_prop_icon4 : GButton
    {
        public GLoader _icon_head;
        public GLoader _icon_border;
        public const string URL = "ui://2r331opvpz0vlf";

        public static com_prop_icon4 CreateInstance()
        {
            return (com_prop_icon4)UIPackage.CreateObject("CommonPKG", "com_prop_icon4");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _icon_head = (GLoader)GetChild("icon_head");
            _icon_border = (GLoader)GetChild("icon_border");
        }
    }
}