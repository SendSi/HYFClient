/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class RebirthItem2 : GComponent
    {
        public Controller _state;
        public GImage _bg;
        public GLoader _icon;
        public GTextField _attrname;
        public GTextField _number1;
        public GTextField _number2;
        public const string URL = "ui://utp01xiaff111ygcft0";

        public static RebirthItem2 CreateInstance()
        {
            return (RebirthItem2)UIPackage.CreateObject("DialogTip", "RebirthItem2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _bg = (GImage)GetChild("bg");
            _icon = (GLoader)GetChild("icon");
            _attrname = (GTextField)GetChild("attrname");
            _number1 = (GTextField)GetChild("number1");
            _number2 = (GTextField)GetChild("number2");
        }
    }
}