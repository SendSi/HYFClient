/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class chargeItem : GButton
    {
        public GTextField _title1;
        public GTextField _title2;
        public GButton _reward;
        public GTextField _timeCount;
        public GList _list;
        public const string URL = "ui://340eighfd1gb1ygcflv";

        public static chargeItem CreateInstance()
        {
            return (chargeItem)UIPackage.CreateObject("Welfare", "chargeItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _title1 = (GTextField)GetChild("title1");
            _title2 = (GTextField)GetChild("title2");
            _reward = (GButton)GetChild("reward");
            _timeCount = (GTextField)GetChild("timeCount");
            _list = (GList)GetChild("list");
        }
    }
}