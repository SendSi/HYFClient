/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class posItem : GButton
    {
        public Controller _state;
        public GGraph _line;
        public GTextField _name;
        public const string URL = "ui://utp01xiapxy31ygcfmu";

        public static posItem CreateInstance()
        {
            return (posItem)UIPackage.CreateObject("DialogTip", "posItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _line = (GGraph)GetChild("line");
            _name = (GTextField)GetChild("name");
        }
    }
}