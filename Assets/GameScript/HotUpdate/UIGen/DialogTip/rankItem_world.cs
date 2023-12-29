/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class rankItem_world : GComponent
    {
        public Controller _state;
        public GTextField _rank;
        public GTextField _num;
        public GLoader _icon;
        public const string URL = "ui://utp01xiar1zh1ygcft0";

        public static rankItem_world CreateInstance()
        {
            return (rankItem_world)UIPackage.CreateObject("DialogTip", "rankItem_world");
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