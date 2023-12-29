/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class attribute_item : GButton
    {
        public Controller _state;
        public GTextField _num;
        public const string URL = "ui://2r331opvebe5ci9";

        public static attribute_item CreateInstance()
        {
            return (attribute_item)UIPackage.CreateObject("CommonPKG", "attribute_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _num = (GTextField)GetChild("num");
        }
    }
}