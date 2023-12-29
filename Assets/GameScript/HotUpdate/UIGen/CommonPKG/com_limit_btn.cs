/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_limit_btn : GButton
    {
        public Controller _newRed;
        public Controller _text;
        public Transition _t0;
        public Transition _boxani;
        public const string URL = "ui://2r331opvg38x1ygcfh4";

        public static com_limit_btn CreateInstance()
        {
            return (com_limit_btn)UIPackage.CreateObject("CommonPKG", "com_limit_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _newRed = GetController("newRed");
            _text = GetController("text");
            _t0 = GetTransition("t0");
            _boxani = GetTransition("boxani");
        }
    }
}