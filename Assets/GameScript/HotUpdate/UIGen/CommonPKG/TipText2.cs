/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class TipText2 : GComponent
    {
        public GImage _textBg;
        public GRichTextField _text;
        public GImage _arrow;
        public const string URL = "ui://2r331opvnybhet";

        public static TipText2 CreateInstance()
        {
            return (TipText2)UIPackage.CreateObject("CommonPKG", "TipText2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _textBg = (GImage)GetChild("textBg");
            _text = (GRichTextField)GetChild("text");
            _arrow = (GImage)GetChild("arrow");
        }
    }
}