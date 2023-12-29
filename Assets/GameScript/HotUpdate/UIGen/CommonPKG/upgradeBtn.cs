/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class upgradeBtn : GButton
    {
        public GImage _upgrade;
        public Transition _upgrade_2;
        public const string URL = "ui://2r331opvrjgu1ygcgog";

        public static upgradeBtn CreateInstance()
        {
            return (upgradeBtn)UIPackage.CreateObject("CommonPKG", "upgradeBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _upgrade = (GImage)GetChild("upgrade");
            _upgrade_2 = GetTransition("upgrade");
        }
    }
}