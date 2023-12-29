/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class btn_head5 : GButton
    {
        public Controller _state;
        public GImage _black;
        public GGroup _stae2;
        public const string URL = "ui://2r331opvdxyz1ygcfmi";

        public static btn_head5 CreateInstance()
        {
            return (btn_head5)UIPackage.CreateObject("CommonPKG", "btn_head5");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _black = (GImage)GetChild("black");
            _stae2 = (GGroup)GetChild("stae2");
        }
    }
}