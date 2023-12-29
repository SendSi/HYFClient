/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class troopBloodPbr : GProgressBar
    {
        public Controller _state;
        public const string URL = "ui://2r331opvvntm1qp8ve3";

        public static troopBloodPbr CreateInstance()
        {
            return (troopBloodPbr)UIPackage.CreateObject("CommonPKG", "troopBloodPbr");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
        }
    }
}