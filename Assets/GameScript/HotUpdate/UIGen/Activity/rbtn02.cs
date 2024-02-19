/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class rbtn02 : GButton
    {
        public Controller _state;
        public GLoader _rbtn;
        public GLoader _dot;
        public GTextField _title1;
        public GTextField _title0;
        public const string URL = "ui://sinorujtg6ichz9cz1";

        public static rbtn02 CreateInstance()
        {
            return (rbtn02)UIPackage.CreateObject("Activity", "rbtn02");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _rbtn = (GLoader)GetChild("rbtn");
            _dot = (GLoader)GetChild("dot");
            _title1 = (GTextField)GetChild("title1");
            _title0 = (GTextField)GetChild("title0");
        }
    }
}