/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class tipsAttItem : GComponent
    {
        public GTextField _attrname;
        public GTextField _number;
        public const string URL = "ui://utp01xialdbz1iy5bbp";

        public static tipsAttItem CreateInstance()
        {
            return (tipsAttItem)UIPackage.CreateObject("DialogTip", "tipsAttItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _attrname = (GTextField)GetChild("attrname");
            _number = (GTextField)GetChild("number");
        }
    }
}