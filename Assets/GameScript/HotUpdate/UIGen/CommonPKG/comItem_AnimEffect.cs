/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class comItem_AnimEffect : GButton
    {
        public comItem _comItem;
        public Transition _t0;
        public const string URL = "ui://2r331opvlto01ygcgpa";

        public static comItem_AnimEffect CreateInstance()
        {
            return (comItem_AnimEffect)UIPackage.CreateObject("CommonPKG", "comItem_AnimEffect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _comItem = (comItem)GetChild("comItem");
            _t0 = GetTransition("t0");
        }
    }
}