/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class com_item_lbl : GComponent
    {
        public GRichTextField _title;
        public GRichTextField _title2;
        public const string URL = "ui://2r331opvk6s79ciy";

        public static com_item_lbl CreateInstance()
        {
            return (com_item_lbl)UIPackage.CreateObject("CommonPKG", "com_item_lbl");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _title = (GRichTextField)GetChild("title");
            _title2 = (GRichTextField)GetChild("title2");
        }
    }
}