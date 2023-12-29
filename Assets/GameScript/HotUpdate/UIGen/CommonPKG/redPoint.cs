/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class redPoint : GButton
    {
        public Controller _showCtrl;
        public const string URL = "ui://2r331opvpyiyhz9d6l";

        public static redPoint CreateInstance()
        {
            return (redPoint)UIPackage.CreateObject("CommonPKG", "redPoint");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _showCtrl = GetController("showCtrl");
        }
    }
}