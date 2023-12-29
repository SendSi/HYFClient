/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class ToastItem : GComponent
    {
        public GImage _bg;
        public GRichTextField _titleTxt;
        public GGroup _content;
        public Transition _moveAlpha;
        public const string URL = "ui://2r331opvtixj1ygcg9o";

        public static ToastItem CreateInstance()
        {
            return (ToastItem)UIPackage.CreateObject("CommonPKG", "ToastItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GImage)GetChild("bg");
            _titleTxt = (GRichTextField)GetChild("titleTxt");
            _content = (GGroup)GetChild("content");
            _moveAlpha = GetTransition("moveAlpha");
        }
    }
}