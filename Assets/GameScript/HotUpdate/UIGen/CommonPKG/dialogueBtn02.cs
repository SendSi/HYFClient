/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class dialogueBtn02 : GButton
    {
        public GTextField _contentLbl;
        public const string URL = "ui://2r331opvb9bj1ygcgmf";

        public static dialogueBtn02 CreateInstance()
        {
            return (dialogueBtn02)UIPackage.CreateObject("CommonPKG", "dialogueBtn02");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _contentLbl = (GTextField)GetChild("contentLbl");
        }
    }
}