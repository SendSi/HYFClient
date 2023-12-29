/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_btn_tab5 : GButton
    {
        public Controller _state;
        public GTextField _name;
        public GGraph _mask;
        public const string URL = "ui://2r331opvb2gghz9d6i";

        public static com_btn_tab5 CreateInstance()
        {
            return (com_btn_tab5)UIPackage.CreateObject("CommonPKG", "com_btn_tab5");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _name = (GTextField)GetChild("name");
            _mask = (GGraph)GetChild("mask");
        }
    }
}