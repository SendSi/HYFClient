/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GMView
{
    public partial class GMMainView : GComponent
    {
        public Controller _showCtrl;
        public GGraph _bg;
        public GList _typeList;
        public GList _centerList;
        public GList _oldReList;
        public GGraph _inputBg;
        public GTextInput _inputTxt;
        public GButton _closeButton;
        public GTextField _descTxt;
        public GGroup _group;
        public GButton _leftRightBtn;
        public GButton _sendBtn;
        public GButton _checkCloseBtn;
        public const string URL = "ui://21uyefv8h7e50";

        public static GMMainView CreateInstance()
        {
            return (GMMainView)UIPackage.CreateObject("GMView", "GMMainView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _showCtrl = GetController("showCtrl");
            _bg = (GGraph)GetChild("bg");
            _typeList = (GList)GetChild("typeList");
            _centerList = (GList)GetChild("centerList");
            _oldReList = (GList)GetChild("oldReList");
            _inputBg = (GGraph)GetChild("inputBg");
            _inputTxt = (GTextInput)GetChild("inputTxt");
            _closeButton = (GButton)GetChild("closeButton");
            _descTxt = (GTextField)GetChild("descTxt");
            _group = (GGroup)GetChild("group");
            _leftRightBtn = (GButton)GetChild("leftRightBtn");
            _sendBtn = (GButton)GetChild("sendBtn");
            _checkCloseBtn = (GButton)GetChild("checkCloseBtn");
        }
    }
}