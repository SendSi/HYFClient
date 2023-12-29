/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class RebirthItem3 : GComponent
    {
        public GTextField _attrname;
        public GTextField _number1;
        public GTextField _number2;
        public const string URL = "ui://utp01xia9v8f1ygcftc";

        public static RebirthItem3 CreateInstance()
        {
            return (RebirthItem3)UIPackage.CreateObject("DialogTip", "RebirthItem3");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _attrname = (GTextField)GetChild("attrname");
            _number1 = (GTextField)GetChild("number1");
            _number2 = (GTextField)GetChild("number2");
        }
    }
}