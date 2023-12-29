/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class generalIcon4 : GComponent
    {
        public GLoader _bg;
        public GLoader _quality;
        public GLoader _icon;
        public GTextField _reviveTimeLbl;
        public const string URL = "ui://2r331opvoxy0hz9czd";

        public static generalIcon4 CreateInstance()
        {
            return (generalIcon4)UIPackage.CreateObject("CommonPKG", "generalIcon4");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GLoader)GetChild("bg");
            _quality = (GLoader)GetChild("quality");
            _icon = (GLoader)GetChild("icon");
            _reviveTimeLbl = (GTextField)GetChild("reviveTimeLbl");
        }
    }
}