/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
    public partial class ServerListDetailView : GComponent
    {
        public Controller _stateCtrl;
        public GComponent _bg_01;
        public GLabel _frame;
        public GButton _sureBtn;
        public GTextField _title_01;
        public GTextField _title_02;
        public GRichTextField _title_03;
        public GTextField _title_04;
        public list_clothes_01 _recentlylanded;
        public list_clothes_02 _existing_roles;
        public GGroup _list_01;
        public list_clothes_03 _list_02;
        public GGroup _windows;
        public const string URL = "ui://byy9k3gh7oizi";

        public static ServerListDetailView CreateInstance()
        {
            return (ServerListDetailView)UIPackage.CreateObject("Login", "ServerListDetailView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _stateCtrl = GetController("stateCtrl");
            _bg_01 = (GComponent)GetChild("bg_01");
            _frame = (GLabel)GetChild("frame");
            _sureBtn = (GButton)GetChild("sureBtn");
            _title_01 = (GTextField)GetChild("title_01");
            _title_02 = (GTextField)GetChild("title_02");
            _title_03 = (GRichTextField)GetChild("title_03");
            _title_04 = (GTextField)GetChild("title_04");
            _recentlylanded = (list_clothes_01)GetChild("recentlylanded");
            _existing_roles = (list_clothes_02)GetChild("existing roles");
            _list_01 = (GGroup)GetChild("list_01");
            _list_02 = (list_clothes_03)GetChild("list_02");
            _windows = (GGroup)GetChild("windows");
        }
    }
}