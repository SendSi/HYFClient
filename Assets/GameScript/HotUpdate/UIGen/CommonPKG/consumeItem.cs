/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class consumeItem : GButton
    {
        public Controller _state;
        public GRichTextField _consumeLbl;
        public GRichTextField _need_01;
        public const string URL = "ui://2r331opvn6021qp8vcx";

        public static consumeItem CreateInstance()
        {
            return (consumeItem)UIPackage.CreateObject("CommonPKG", "consumeItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _consumeLbl = (GRichTextField)GetChild("consumeLbl");
            _need_01 = (GRichTextField)GetChild("need_01");
        }
    }
}