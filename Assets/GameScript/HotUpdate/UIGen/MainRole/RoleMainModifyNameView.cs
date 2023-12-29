/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainRole
{
    public partial class RoleMainModifyNameView : GLabel
    {
        public Controller _state;
        public GButton _win;
        public GTextInput _txtInput;
        public GTextField _wordLlimit;
        public GButton _btnSure;
        public GRichTextField _txtCost;
        public GLoader _resultIcon;
        public GGroup _view;
        public const string URL = "ui://66sh7tc6dnyfhz9czj";

        public static RoleMainModifyNameView CreateInstance()
        {
            return (RoleMainModifyNameView)UIPackage.CreateObject("MainRole", "RoleMainModifyNameView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _state = GetController("state");
            _win = (GButton)GetChild("win");
            _txtInput = (GTextInput)GetChild("txtInput");
            _wordLlimit = (GTextField)GetChild("wordLlimit");
            _btnSure = (GButton)GetChild("btnSure");
            _txtCost = (GRichTextField)GetChild("txtCost");
            _resultIcon = (GLoader)GetChild("resultIcon");
            _view = (GGroup)GetChild("view");
        }
    }
}