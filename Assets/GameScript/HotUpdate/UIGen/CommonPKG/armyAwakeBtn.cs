/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class armyAwakeBtn : GComponent
    {
        public Controller _redDot;
        public Controller _hint;
        public armyBtn _ArmyBtn;
        public GTextField _armTitle;
        public const string URL = "ui://2r331opvspxy1ygcflp";

        public static armyAwakeBtn CreateInstance()
        {
            return (armyAwakeBtn)UIPackage.CreateObject("CommonPKG", "armyAwakeBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _redDot = GetController("redDot");
            _hint = GetController("hint");
            _ArmyBtn = (armyBtn)GetChild("ArmyBtn");
            _armTitle = (GTextField)GetChild("armTitle");
        }
    }
}