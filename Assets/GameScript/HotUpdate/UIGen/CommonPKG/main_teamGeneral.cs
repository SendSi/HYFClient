/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class main_teamGeneral : GComponent
    {
        public GLoader _icon;
        public const string URL = "ui://2r331opvoepthz9cp0";

        public static main_teamGeneral CreateInstance()
        {
            return (main_teamGeneral)UIPackage.CreateObject("CommonPKG", "main_teamGeneral");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _icon = (GLoader)GetChild("icon");
        }
    }
}