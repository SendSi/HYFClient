/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class generalFragment01 : GComponent
    {
        public GLoader _icon;
        public const string URL = "ui://2r331opvlxji1ygcgph";

        public static generalFragment01 CreateInstance()
        {
            return (generalFragment01)UIPackage.CreateObject("CommonPKG", "generalFragment01");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _icon = (GLoader)GetChild("icon");
        }
    }
}