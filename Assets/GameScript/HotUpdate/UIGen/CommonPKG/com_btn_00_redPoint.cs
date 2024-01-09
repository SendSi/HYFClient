/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_btn_00_redPoint : GButton
    {
        public RedPoint _redElement;
        public const string URL = "ui://2r331opvitkw1ygcfkf";

        public static com_btn_00_redPoint CreateInstance()
        {
            return (com_btn_00_redPoint)UIPackage.CreateObject("CommonPKG", "com_btn_00_redPoint");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _redElement = (RedPoint)GetChild("redElement");
        }
    }
}