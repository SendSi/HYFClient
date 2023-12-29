/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogNameView : GLabel
    {
        public GComponent _mask;
        public GTextField _titleTxt;
        public GButton _btnRight;
        public GTextInput _checkInput;
        public GTextField _tips;
        public GButton _closeButton;
        public const string URL = "ui://utp01xiabwlb1iy5bbl";

        public static DialogNameView CreateInstance()
        {
            return (DialogNameView)UIPackage.CreateObject("DialogTip", "DialogNameView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _titleTxt = (GTextField)GetChild("titleTxt");
            _btnRight = (GButton)GetChild("btnRight");
            _checkInput = (GTextInput)GetChild("checkInput");
            _tips = (GTextField)GetChild("tips");
            _closeButton = (GButton)GetChild("closeButton");
        }
    }
}