/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_btn_01_redPoint : GButton
    {
        public redPoint _redElement;
        public const string URL = "ui://2r331opvsd0v1ygcfky";

        public static com_btn_01_redPoint CreateInstance()
        {
            return (com_btn_01_redPoint)UIPackage.CreateObject("CommonPKG", "com_btn_01_redPoint");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _redElement = (redPoint)GetChild("redElement");
        }
    }
}