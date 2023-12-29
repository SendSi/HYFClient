/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DialogTip
{
    public partial class DialogTipCoordinateView : GLabel
    {
        public Controller _contentCtrl;
        public GLabel _bg;
        public GTextField _titleTxt;
        public GTextField _contentTxt;
        public GTextField _nullTxt;
        public GList _posList;
        public GButton _closeButton;
        public GGroup _window;
        public const string URL = "ui://utp01xiapxy31ygcfi3";

        public static DialogTipCoordinateView CreateInstance()
        {
            return (DialogTipCoordinateView)UIPackage.CreateObject("DialogTip", "DialogTipCoordinateView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _contentCtrl = GetController("contentCtrl");
            _bg = (GLabel)GetChild("bg");
            _titleTxt = (GTextField)GetChild("titleTxt");
            _contentTxt = (GTextField)GetChild("contentTxt");
            _nullTxt = (GTextField)GetChild("nullTxt");
            _posList = (GList)GetChild("posList");
            _closeButton = (GButton)GetChild("closeButton");
            _window = (GGroup)GetChild("window");
        }
    }
}