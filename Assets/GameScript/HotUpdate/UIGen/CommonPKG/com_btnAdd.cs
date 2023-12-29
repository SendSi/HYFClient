/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_btnAdd : GButton
    {
        public Controller _plus;
        public GTextField _0_haveTitle;
        public GTextField _1_haveTitle;
        public GGroup _1_yesPlus;
        public Transition _t0;
        public const string URL = "ui://2r331opvrb1rl1";

        public static com_btnAdd CreateInstance()
        {
            return (com_btnAdd)UIPackage.CreateObject("CommonPKG", "com_btnAdd");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _plus = GetController("plus");
            _0_haveTitle = (GTextField)GetChild("0_haveTitle");
            _1_haveTitle = (GTextField)GetChild("1_haveTitle");
            _1_yesPlus = (GGroup)GetChild("1_yesPlus");
            _t0 = GetTransition("t0");
        }
    }
}