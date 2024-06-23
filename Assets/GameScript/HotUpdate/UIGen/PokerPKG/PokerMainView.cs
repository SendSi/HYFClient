/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace PokerPKG
{
    public partial class PokerMainView : GComponent
    {
        public Controller _stateCtrl;
        public GLoader _bg;
        public GLoader _leftRole;
        public GLoader _rightRole;
        public GLoader _selfRole;
        public GList _leftSendCardList;
        public GList _rightSendCardList;
        public GList _selfSendCardList;
        public GButton _preparationBtn;
        public GGroup _state0;
        public GButton _sendPokerBtn;
        public GButton _giveUpBtn;
        public GGroup _state1;
        public GButton _closeButton;
        public GList _selfCardList;
        public GList _leftCardList;
        public GList _rightCardList;
        public GList _topCardList;
        public const string URL = "ui://q3kpafy9zift1ygcga7";

        public static PokerMainView CreateInstance()
        {
            return (PokerMainView)UIPackage.CreateObject("PokerPKG", "PokerMainView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _stateCtrl = GetController("stateCtrl");
            _bg = (GLoader)GetChild("bg");
            _leftRole = (GLoader)GetChild("leftRole");
            _rightRole = (GLoader)GetChild("rightRole");
            _selfRole = (GLoader)GetChild("selfRole");
            _leftSendCardList = (GList)GetChild("leftSendCardList");
            _rightSendCardList = (GList)GetChild("rightSendCardList");
            _selfSendCardList = (GList)GetChild("selfSendCardList");
            _preparationBtn = (GButton)GetChild("preparationBtn");
            _state0 = (GGroup)GetChild("state0");
            _sendPokerBtn = (GButton)GetChild("sendPokerBtn");
            _giveUpBtn = (GButton)GetChild("giveUpBtn");
            _state1 = (GGroup)GetChild("state1");
            _closeButton = (GButton)GetChild("closeButton");
            _selfCardList = (GList)GetChild("selfCardList");
            _leftCardList = (GList)GetChild("leftCardList");
            _rightCardList = (GList)GetChild("rightCardList");
            _topCardList = (GList)GetChild("topCardList");
        }
    }
}