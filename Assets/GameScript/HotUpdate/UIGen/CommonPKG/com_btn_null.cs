/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_btn_null : GButton
    {
        public Transition _transition;
        public const string URL = "ui://2r331opvsfia1ygcfhf";

        public static com_btn_null CreateInstance()
        {
            return (com_btn_null)UIPackage.CreateObject("CommonPKG", "com_btn_null");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _transition = GetTransition("transition");
        }
    }
}