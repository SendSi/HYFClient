/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_tips : GComponent
    {
        public Controller _state;
        public GTextField _title;
        public Transition _t1;
        public Transition _t3;
        public const string URL = "ui://2r331opvbyqs1ygcfhd";

        public static com_tips CreateInstance()
        {
            return (com_tips)UIPackage.CreateObject("CommonPKG", "com_tips");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _title = (GTextField)GetChild("title");
            _t1 = GetTransition("t1");
            _t3 = GetTransition("t3");
        }
    }
}