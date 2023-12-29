/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class getPbr : GProgressBar
    {
        public Controller _color;
        public GImage _bar1;
        public GTextField _descLbl;
        public const string URL = "ui://utp01xiat2qk1iy5bbq";

        public static getPbr CreateInstance()
        {
            return (getPbr)UIPackage.CreateObject("DialogTip", "getPbr");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _color = GetController("color");
            _bar1 = (GImage)GetChild("bar1");
            _descLbl = (GTextField)GetChild("descLbl");
        }
    }
}