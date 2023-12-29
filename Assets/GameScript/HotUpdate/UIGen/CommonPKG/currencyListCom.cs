/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class currencyListCom : GComponent
    {
        public GList _currencyList;
        public const string URL = "ui://2r331opvykwwkx";

        public static currencyListCom CreateInstance()
        {
            return (currencyListCom)UIPackage.CreateObject("CommonPKG", "currencyListCom");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _currencyList = (GList)GetChild("currencyList");
        }
    }
}