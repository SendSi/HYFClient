/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GMView
{
    public partial class gmView : GComponent
    {
        public Controller _c1;
        public GList _typeList;
        public GList _centerList;
        public GList _oldReList;
        public GGraph _inputBg;
        public GTextInput _input;
        public GButton _closeButton;
        public GTextField _descTxt;
        public GButton _leftRightBtn;
        public btn _sendBtn;
        public GButton _checkCloseBtn;
        public const string URL = "ui://21uyefv8h7e50";

        public static gmView CreateInstance()
        {
            return (gmView)UIPackage.CreateObject("GMView", "gmView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _c1 = GetController("c1");
            _typeList = (GList)GetChild("typeList");
            _centerList = (GList)GetChild("centerList");
            _oldReList = (GList)GetChild("oldReList");
            _inputBg = (GGraph)GetChild("inputBg");
            _input = (GTextInput)GetChild("input");
            _closeButton = (GButton)GetChild("closeButton");
            _descTxt = (GTextField)GetChild("descTxt");
            _leftRightBtn = (GButton)GetChild("leftRightBtn");
            _sendBtn = (btn)GetChild("sendBtn");
            _checkCloseBtn = (GButton)GetChild("checkCloseBtn");
        }
    }
}