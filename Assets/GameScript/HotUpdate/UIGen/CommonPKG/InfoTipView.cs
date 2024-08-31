/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class InfoTipView : GComponent
    {
        public GComponent _bg_01;
        public WindowFrame _frame;
        public titleContent _content;
        public const string URL = "ui://2r331opvmnqw1ygcga7";

        public static InfoTipView CreateInstance()
        {
            return (InfoTipView)UIPackage.CreateObject("CommonPKG", "InfoTipView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg_01 = (GComponent)GetChild("bg_01");
            _frame = (WindowFrame)GetChild("frame");
            _content = (titleContent)GetChild("content");
        }
    }
}