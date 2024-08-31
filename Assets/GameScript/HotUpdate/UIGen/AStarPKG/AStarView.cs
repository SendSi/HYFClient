/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace AStarPKG
{
    public partial class AStarView : GComponent
    {
        public GImage _bg;
        public Item_ColorLeft _btn0;
        public Item_ColorLeft _btn1;
        public Item_ColorLeft _btn2;
        public Item_ColorLeft _btn3;
        public Item_ColorLeft _btn4;
        public GTextInput _inputWidth;
        public GTextInput _inputHeight;
        public GTextInput _inputPass;
        public GButton _btnGenerate;
        public GButton _btnReset;
        public GList _listContent;
        public GButton _closeButton;
        public GTextField _titleLeft;
        public GButton _exTipBtn;
        public const string URL = "ui://lqtfwinih90bl7";

        public static AStarView CreateInstance()
        {
            return (AStarView)UIPackage.CreateObject("AStarPKG", "AStarView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GImage)GetChild("bg");
            _btn0 = (Item_ColorLeft)GetChild("btn0");
            _btn1 = (Item_ColorLeft)GetChild("btn1");
            _btn2 = (Item_ColorLeft)GetChild("btn2");
            _btn3 = (Item_ColorLeft)GetChild("btn3");
            _btn4 = (Item_ColorLeft)GetChild("btn4");
            _inputWidth = (GTextInput)GetChild("inputWidth");
            _inputHeight = (GTextInput)GetChild("inputHeight");
            _inputPass = (GTextInput)GetChild("inputPass");
            _btnGenerate = (GButton)GetChild("btnGenerate");
            _btnReset = (GButton)GetChild("btnReset");
            _listContent = (GList)GetChild("listContent");
            _closeButton = (GButton)GetChild("closeButton");
            _titleLeft = (GTextField)GetChild("titleLeft");
            _exTipBtn = (GButton)GetChild("exTipBtn");
        }
    }
}