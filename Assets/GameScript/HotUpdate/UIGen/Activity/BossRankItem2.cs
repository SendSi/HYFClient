/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class BossRankItem2 : GComponent
    {
        public Controller _state;
        public GProgressBar _barh_2;
        public GProgressBar _bar_2;
        public GProgressBar _barh_1;
        public GProgressBar _bar_1;
        public GTextField _rankNum;
        public GTextField _nameLbl;
        public GTextField _harmLbl;
        public const string URL = "ui://sinorujtw2ss1ygcfh4";

        public static BossRankItem2 CreateInstance()
        {
            return (BossRankItem2)UIPackage.CreateObject("Activity", "BossRankItem2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _barh_2 = (GProgressBar)GetChild("barh_2");
            _bar_2 = (GProgressBar)GetChild("bar_2");
            _barh_1 = (GProgressBar)GetChild("barh_1");
            _bar_1 = (GProgressBar)GetChild("bar_1");
            _rankNum = (GTextField)GetChild("rankNum");
            _nameLbl = (GTextField)GetChild("nameLbl");
            _harmLbl = (GTextField)GetChild("harmLbl");
        }
    }
}