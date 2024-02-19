/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class rbtn04 : GButton
    {
        public Controller _reddot;
        public GLoader _label;
        public GButton _reddot_2;
        public const string URL = "ui://sinorujtqabg1ygcfif";

        public static rbtn04 CreateInstance()
        {
            return (rbtn04)UIPackage.CreateObject("Activity", "rbtn04");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _reddot = GetController("reddot");
            _label = (GLoader)GetChild("label");
            _reddot_2 = (GButton)GetChild("reddot");
        }
    }
}