/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class ExplainTipView : GLabel
    {
        public GComponent _mask;
        public GLabel _bg;
        public GButton _closeButton;
        public contentTxt _contentTxt;
        public GList _list;
        public GTextField _titleTxt;
        public GGroup _win;
        public const string URL = "ui://utp01xiaplmm2t";

        public static ExplainTipView CreateInstance()
        {
            return (ExplainTipView)UIPackage.CreateObject("DialogTip", "ExplainTipView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _bg = (GLabel)GetChild("bg");
            _closeButton = (GButton)GetChild("closeButton");
            _contentTxt = (contentTxt)GetChild("contentTxt");
            _list = (GList)GetChild("list");
            _titleTxt = (GTextField)GetChild("titleTxt");
            _win = (GGroup)GetChild("win");
        }
    }
}