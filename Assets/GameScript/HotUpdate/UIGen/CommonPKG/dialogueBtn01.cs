/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class dialogueBtn01 : GButton
    {
        public GTextField _contentLbl;
        public const string URL = "ui://2r331opvb9bj2";

        public static dialogueBtn01 CreateInstance()
        {
            return (dialogueBtn01)UIPackage.CreateObject("CommonPKG", "dialogueBtn01");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _contentLbl = (GTextField)GetChild("contentLbl");
        }
    }
}