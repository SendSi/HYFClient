/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class tokenItem : GButton
    {
        public GTextField _0_haveTitle;
        public Transition _t0;
        public const string URL = "ui://2r331opvf6nohz9cnx";

        public static tokenItem CreateInstance()
        {
            return (tokenItem)UIPackage.CreateObject("CommonPKG", "tokenItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _0_haveTitle = (GTextField)GetChild("0_haveTitle");
            _t0 = GetTransition("t0");
        }
    }
}