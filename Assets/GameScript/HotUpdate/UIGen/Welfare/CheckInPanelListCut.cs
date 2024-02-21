/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class CheckInPanelListCut : GComponent
    {
        public GList _dayList;
        public const string URL = "ui://340eighfrs9w1ygcfmt";

        public static CheckInPanelListCut CreateInstance()
        {
            return (CheckInPanelListCut)UIPackage.CreateObject("Welfare", "CheckInPanelListCut");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _dayList = (GList)GetChild("dayList");
        }
    }
}