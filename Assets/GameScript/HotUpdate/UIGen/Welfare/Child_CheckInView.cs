/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class Child_CheckInView : GComponent
    {
        public GLoader _bgIcon;
        public GTextField _titleTxt;
        public GTextField _timerTxt;
        public CheckInPanelListCut _dayCom;
        public GTextField _descTxt;
        public const string URL = "ui://340eighfrs9w1ygcfmv";

        public static Child_CheckInView CreateInstance()
        {
            return (Child_CheckInView)UIPackage.CreateObject("Welfare", "Child_CheckInView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bgIcon = (GLoader)GetChild("bgIcon");
            _titleTxt = (GTextField)GetChild("titleTxt");
            _timerTxt = (GTextField)GetChild("timerTxt");
            _dayCom = (CheckInPanelListCut)GetChild("dayCom");
            _descTxt = (GTextField)GetChild("descTxt");
        }
    }
}