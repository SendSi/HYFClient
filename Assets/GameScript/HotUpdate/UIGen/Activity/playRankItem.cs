/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Activity
{
    public partial class playRankItem : GButton
    {
        public Controller _atate;
        public GTextField _unionLbl;
        public GTextField _difficultyLbl;
        public GTextField _timeLbl;
        public const string URL = "ui://sinorujtcvsphz9d0c";

        public static playRankItem CreateInstance()
        {
            return (playRankItem)UIPackage.CreateObject("Activity", "playRankItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _atate = GetController("atate");
            _unionLbl = (GTextField)GetChild("unionLbl");
            _difficultyLbl = (GTextField)GetChild("difficultyLbl");
            _timeLbl = (GTextField)GetChild("timeLbl");
        }
    }
}