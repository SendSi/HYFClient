/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_btn_tab03_redPoint : GButton
    {
        public GLoader _bg;
        public GTextField _title0;
        public GTextField _title1;
        public RedPoint _redElement;
        public const string URL = "ui://2r331opvmw3o1ygcflo";

        public static com_btn_tab03_redPoint CreateInstance()
        {
            return (com_btn_tab03_redPoint)UIPackage.CreateObject("CommonPKG", "com_btn_tab03_redPoint");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GLoader)GetChild("bg");
            _title0 = (GTextField)GetChild("title0");
            _title1 = (GTextField)GetChild("title1");
            _redElement = (RedPoint)GetChild("redElement");
        }
    }
}