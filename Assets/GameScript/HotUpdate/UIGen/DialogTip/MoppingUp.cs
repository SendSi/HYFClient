/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class MoppingUp : GLabel
    {
        public GComponent _mask;
        public GLabel _window;
        public GTextField _titleTxt;
        public GRichTextField _tips;
        public GList _list;
        public GTextField _Lbl01;
        public GRichTextField _Lbl02;
        public GRichTextField _Lbl03;
        public GButton _getBtn;
        public GButton _plusBtn;
        public GButton _reduceBtn;
        public GButton _closeButton;
        public const string URL = "ui://utp01xiauckw1ygcfhv";

        public static MoppingUp CreateInstance()
        {
            return (MoppingUp)UIPackage.CreateObject("DialogTip", "MoppingUp");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _window = (GLabel)GetChild("window");
            _titleTxt = (GTextField)GetChild("titleTxt");
            _tips = (GRichTextField)GetChild("tips");
            _list = (GList)GetChild("list");
            _Lbl01 = (GTextField)GetChild("Lbl01");
            _Lbl02 = (GRichTextField)GetChild("Lbl02");
            _Lbl03 = (GRichTextField)GetChild("Lbl03");
            _getBtn = (GButton)GetChild("getBtn");
            _plusBtn = (GButton)GetChild("plusBtn");
            _reduceBtn = (GButton)GetChild("reduceBtn");
            _closeButton = (GButton)GetChild("closeButton");
        }
    }
}