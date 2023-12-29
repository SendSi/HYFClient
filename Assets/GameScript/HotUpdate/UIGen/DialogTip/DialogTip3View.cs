/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogTip3View : GLabel
    {
        public GComponent _mask;
        public GButton _closeButton;
        public GTextField _titleTxt;
        public GTextField _befor;
        public GTextField _after;
        public GTextField _tips;
        public GButton _btnCenter;
        public const string URL = "ui://utp01xiaeznb1iy5bbi";

        public static DialogTip3View CreateInstance()
        {
            return (DialogTip3View)UIPackage.CreateObject("DialogTip", "DialogTip3View");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _closeButton = (GButton)GetChild("closeButton");
            _titleTxt = (GTextField)GetChild("titleTxt");
            _befor = (GTextField)GetChild("befor");
            _after = (GTextField)GetChild("after");
            _tips = (GTextField)GetChild("tips");
            _btnCenter = (GButton)GetChild("btnCenter");
        }
    }
}