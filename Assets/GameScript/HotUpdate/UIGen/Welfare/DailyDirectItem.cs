/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class DailyDirectItem : GComponent
    {
        public GGraph _mask;
        public GList _rewardList;
        public Transition _admission;
        public const string URL = "ui://340eighfnkto1ygcgou";

        public static DailyDirectItem CreateInstance()
        {
            return (DailyDirectItem)UIPackage.CreateObject("Welfare", "DailyDirectItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GGraph)GetChild("mask");
            _rewardList = (GList)GetChild("rewardList");
            _admission = GetTransition("admission");
        }
    }
}