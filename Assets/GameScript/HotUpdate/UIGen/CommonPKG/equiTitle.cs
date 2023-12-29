/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class equiTitle : GComponent
    {
        public Controller _quality;
        public GTextField _propTitle;
        public const string URL = "ui://2r331opvpoazl1";

        public static equiTitle CreateInstance()
        {
            return (equiTitle)UIPackage.CreateObject("CommonPKG", "equiTitle");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _quality = GetController("quality");
            _propTitle = (GTextField)GetChild("propTitle");
        }
    }
}