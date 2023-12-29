/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class iconItem2 : GButton
    {
        public Controller _state;
        public const string URL = "ui://2r331opvb1o21ygcfno";

        public static iconItem2 CreateInstance()
        {
            return (iconItem2)UIPackage.CreateObject("CommonPKG", "iconItem2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
        }
    }
}