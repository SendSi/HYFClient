/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class iconItem : GButton
    {
        public Controller _state;
        public Controller _show;
        public const string URL = "ui://2r331opvjs41hz9cw1";

        public static iconItem CreateInstance()
        {
            return (iconItem)UIPackage.CreateObject("CommonPKG", "iconItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _show = GetController("show");
        }
    }
}