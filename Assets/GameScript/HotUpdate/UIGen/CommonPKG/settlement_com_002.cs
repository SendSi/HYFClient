/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class settlement_com_002 : GButton
    {
        public GLoader _bg01;
        public const string URL = "ui://2r331opvosur1ygcfn4";

        public static settlement_com_002 CreateInstance()
        {
            return (settlement_com_002)UIPackage.CreateObject("CommonPKG", "settlement_com_002");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg01 = (GLoader)GetChild("bg01");
        }
    }
}