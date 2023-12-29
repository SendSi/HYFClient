/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_item_upgrade2 : GComponent
    {
        public GRichTextField _title;
        public GRichTextField _num1;
        public GRichTextField _num2;
        public const string URL = "ui://2r331opv91o91ygcfku";

        public static com_item_upgrade2 CreateInstance()
        {
            return (com_item_upgrade2)UIPackage.CreateObject("CommonPKG", "com_item_upgrade2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _title = (GRichTextField)GetChild("title");
            _num1 = (GRichTextField)GetChild("num1");
            _num2 = (GRichTextField)GetChild("num2");
        }
    }
}