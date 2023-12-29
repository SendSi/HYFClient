/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class resourceNum : GButton
    {
        public Controller _c1;
        public GTextField _num;
        public const string URL = "ui://2r331opvb2gghz9d6h";

        public static resourceNum CreateInstance()
        {
            return (resourceNum)UIPackage.CreateObject("CommonPKG", "resourceNum");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _c1 = GetController("c1");
            _num = (GTextField)GetChild("num");
        }
    }
}