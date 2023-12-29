/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_btn_buy6 : GButton
    {
        public GTextField _timeLbl;
        public const string URL = "ui://2r331opvl6381qp8veh";

        public static com_btn_buy6 CreateInstance()
        {
            return (com_btn_buy6)UIPackage.CreateObject("CommonPKG", "com_btn_buy6");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _timeLbl = (GTextField)GetChild("timeLbl");
        }
    }
}