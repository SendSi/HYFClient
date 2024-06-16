/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GuidePKG
{
    public partial class TipText : GComponent
    {
        public GLoader _textBg;
        public GTextField _text;
        public GTextField _textTip;
        public GLoader _tipimg;
        public Transition _t0;
        public const string URL = "ui://vypq82a1gyzy8";

        public static TipText CreateInstance()
        {
            return (TipText)UIPackage.CreateObject("GuidePKG", "TipText");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _textBg = (GLoader)GetChild("textBg");
            _text = (GTextField)GetChild("text");
            _textTip = (GTextField)GetChild("textTip");
            _tipimg = (GLoader)GetChild("tipimg");
            _t0 = GetTransition("t0");
        }
    }
}