/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogItemListView : GLabel
    {
        public GComponent _mask;
        public GLabel _window;
        public GTextField _titleTxt;
        public GTextField _tipTxt;
        public GList _propList;
        public GButton _closeButton;
        public GButton _btnLeft;
        public GButton _btnRight;
        public const string URL = "ui://utp01xiawb0l1ygcfmv";

        public static DialogItemListView CreateInstance()
        {
            return (DialogItemListView)UIPackage.CreateObject("DialogTip", "DialogItemListView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _mask = (GComponent)GetChild("mask");
            _window = (GLabel)GetChild("window");
            _titleTxt = (GTextField)GetChild("titleTxt");
            _tipTxt = (GTextField)GetChild("tipTxt");
            _propList = (GList)GetChild("propList");
            _closeButton = (GButton)GetChild("closeButton");
            _btnLeft = (GButton)GetChild("btnLeft");
            _btnRight = (GButton)GetChild("btnRight");
        }
    }
}