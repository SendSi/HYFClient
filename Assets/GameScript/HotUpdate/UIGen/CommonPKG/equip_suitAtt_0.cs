/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class equip_suitAtt_0 : GComponent
    {
        public Controller _switch;
        public GList _list;
        public GTextField _tips;
        public const string URL = "ui://2r331opvs1351iy5b9f";

        public static equip_suitAtt_0 CreateInstance()
        {
            return (equip_suitAtt_0)UIPackage.CreateObject("CommonPKG", "equip_suitAtt_0");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _switch = GetController("switch");
            _list = (GList)GetChild("list");
            _tips = (GTextField)GetChild("tips");
        }
    }
}