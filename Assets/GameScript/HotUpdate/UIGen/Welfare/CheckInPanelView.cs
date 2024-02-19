/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class CheckInPanelView : GComponent
    {
        public GLoader _Personal_leader;
        public GTextField _describelbl01;
        public GTextField _describelbl;
        public CheckInPanelListCut _list;
        public GTextField _fresh;
        public const string URL = "ui://340eighfrs9w1ygcfmv";

        public static CheckInPanelView CreateInstance()
        {
            return (CheckInPanelView)UIPackage.CreateObject("Welfare", "CheckInPanelView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _Personal_leader = (GLoader)GetChild("Personal_leader");
            _describelbl01 = (GTextField)GetChild("describelbl01");
            _describelbl = (GTextField)GetChild("describelbl");
            _list = (CheckInPanelListCut)GetChild("list");
            _fresh = (GTextField)GetChild("fresh");
        }
    }
}