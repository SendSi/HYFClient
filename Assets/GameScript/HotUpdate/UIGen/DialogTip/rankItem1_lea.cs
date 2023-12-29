/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class rankItem1_lea : GComponent
    {
        public Controller _state;
        public GTextField _rank;
        public GTextField _num;
        public GLoader _icon;
        public const string URL = "ui://utp01xiadi051ygcft0";

        public static rankItem1_lea CreateInstance()
        {
            return (rankItem1_lea)UIPackage.CreateObject("DialogTip", "rankItem1_lea");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _rank = (GTextField)GetChild("rank");
            _num = (GTextField)GetChild("num");
            _icon = (GLoader)GetChild("icon");
        }
    }
}