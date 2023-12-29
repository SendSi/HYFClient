/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogPropNotEnough : GLabel
    {
        public Controller _state;
        public GComponent _mask;
        public GLabel _window;
        public GTextField _titleTxt;
        public GTextField _tips;
        public GList _propList;
        public GButton _getBtn;
        public GButton _receiveBtn;
        public GButton _closeButton;
        public const string URL = "ui://utp01xiaspte39";

        public static DialogPropNotEnough CreateInstance()
        {
            return (DialogPropNotEnough)UIPackage.CreateObject("DialogTip", "DialogPropNotEnough");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _mask = (GComponent)GetChild("mask");
            _window = (GLabel)GetChild("window");
            _titleTxt = (GTextField)GetChild("titleTxt");
            _tips = (GTextField)GetChild("tips");
            _propList = (GList)GetChild("propList");
            _getBtn = (GButton)GetChild("getBtn");
            _receiveBtn = (GButton)GetChild("receiveBtn");
            _closeButton = (GButton)GetChild("closeButton");
        }
    }
}