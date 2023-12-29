/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class RebirthItem1 : GComponent
    {
        public GTextField _attrname;
        public GTextField _number1;
        public GTextField _number2;
        public GComponent _hero;
        public GTextField _lv;
        public GTextField _number3;
        public GTextField _number4;
        public const string URL = "ui://utp01xiaff111ygcft1";

        public static RebirthItem1 CreateInstance()
        {
            return (RebirthItem1)UIPackage.CreateObject("DialogTip", "RebirthItem1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _attrname = (GTextField)GetChild("attrname");
            _number1 = (GTextField)GetChild("number1");
            _number2 = (GTextField)GetChild("number2");
            _hero = (GComponent)GetChild("hero");
            _lv = (GTextField)GetChild("lv");
            _number3 = (GTextField)GetChild("number3");
            _number4 = (GTextField)GetChild("number4");
        }
    }
}