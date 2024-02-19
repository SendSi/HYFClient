/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class troops : GComponent
    {
        public GComponent _generalIcon;
        public GTextField _gradelbl;
        public GSlider _slider;
        public GImage _line;
        public GTextField _levelLbl;
        public GTextField _reviveTimeLbl;
        public const string URL = "ui://sinorujtithohz9cyh";

        public static troops CreateInstance()
        {
            return (troops)UIPackage.CreateObject("Activity", "troops");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _generalIcon = (GComponent)GetChild("generalIcon");
            _gradelbl = (GTextField)GetChild("gradelbl");
            _slider = (GSlider)GetChild("slider");
            _line = (GImage)GetChild("line");
            _levelLbl = (GTextField)GetChild("levelLbl");
            _reviveTimeLbl = (GTextField)GetChild("reviveTimeLbl");
        }
    }
}