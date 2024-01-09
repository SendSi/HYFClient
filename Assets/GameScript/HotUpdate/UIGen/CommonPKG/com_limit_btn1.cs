/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_limit_btn1 : GButton
    {
        public Controller _newRed;
        public RedPoint _redpoint;
        public Transition _t0;
        public const string URL = "ui://2r331opv8lkd1ygcfm3";

        public static com_limit_btn1 CreateInstance()
        {
            return (com_limit_btn1)UIPackage.CreateObject("CommonPKG", "com_limit_btn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _newRed = GetController("newRed");
            _redpoint = (RedPoint)GetChild("redpoint");
            _t0 = GetTransition("t0");
        }
    }
}